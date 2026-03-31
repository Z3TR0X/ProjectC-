using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 : Form {
		private void ExportConfig(object sender, EventArgs e) {
			SaveFileDialog FileDialog = new SaveFileDialog();
			FileDialog.Filter = "Fichier SQLite (*.db)|*.db|Tous les fichiers (*.*)|*.*";
			FileDialog.Title = "Exporter le projet";
			FileDialog.FileName = "Project Plotter " + DateTime.Now.ToString("dd-MM-yy") + ".db"; ;

			if (FileDialog.ShowDialog() != DialogResult.OK) return;

			if (IsFileLocked(FileDialog.FileName)) {
                MessageBox.Show("Le fichier est déja\n utilisé par un\nautre processus", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
            }
			if (File.Exists(FileDialog.FileName)) {
				File.Delete(FileDialog.FileName);
			}
			CreateDataBase(FileDialog.FileName);

			MessageBox.Show("Projet Sauvegardé\navec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void CreateDataBase(string path) {
            using (var connection = new SQLiteConnection($"Data Source={path}")) {
                connection.Open();

                SQLiteCommand createCommand = connection.CreateCommand();

                createCommand.CommandText = @"
                    CREATE TABLE IF NOT EXISTS DataInfo(
						Id INTEGER PRIMARY KEY,
						Name TEXT NOT NULL,
						Color INTEGER NOT NULL,
						IsDataCustomised BOOLEAN NOT NULL,
						Expression TEXT NOT NULL
					);

					CREATE TABLE IF NOT EXISTS Time(
						Id INTEGER PRIMARY KEY AUTOINCREMENT,
						Value REAL NOT NULL
					);

					CREATE TABLE IF NOT EXISTS window(
						Id INTEGER PRIMARY KEY,
						Name text NOT NULL,
						nbPlots int NOT NULL,
						IsSelected boolean NOT NULL
					);

					CREATE TABLE IF NOT EXISTS console(
						Id INTEGER PRIMARY KEY,
						Name text NOT NULL,
						IsForcedBottom boolean NOT NULL,
						IsTimeStampActive boolean NOT NULL,
						IsSelected boolean NOT NULL
					);

					CREATE TABLE IF NOT EXISTS PlotInfoWindow(
						Id INTEGER PRIMARY KEY AUTOINCREMENT,
						Name text NOT NULL,
						PlotId INTEGER NOT NULL,
						DataPloted text NOT NULL, --C'est une chaine de caractère qui repésente un tableau d'int
						DataLoc TEXT NOT NULL, --Tableau de char
						LeftAxisLimit text NOT NULL, -- Tableau d'int,
						RightAxisLimit text NOT NULL, -- Tableau d'int 
						BottomAxisLimit text NOT NULL,  -- Tableau d'int 
						windowId INTEGER NOT NULL,
	
						CONSTRAINT fk_window_id FOREIGN KEY(windowId) REFERENCES window(Id)
	
					);
                ";
				foreach(string name in DatasName) {
					createCommand.CommandText += @"CREATE TABLE IF NOT EXISTS [" + name + @"](
							Id INTEGER PRIMARY KEY AUTOINCREMENT,
							Value REAL NOT NULL
						);
					";

                }
                createCommand.ExecuteNonQuery();

				SQLiteCommand insertCommand = connection.CreateCommand();

				//Met a jour les limites d'axes pour la fenêtre active
                for (int i = 0; i < Plots.Count; i++) {
                    activeWindow.Item1.plots[i].axisLimit['l'] = Plots[i].GetAxesLimits('l');
                    activeWindow.Item1.plots[i].axisLimit['r'] = Plots[i].GetAxesLimits('r');
                    activeWindow.Item1.plots[i].axisLimit['b'] = Plots[i].GetAxesLimits('b');
                }

                //Stocker les windows
                foreach ((Window, PanelWindowControl) winTuple in windows) { 
					Window win = winTuple.Item1;
					int id = winTuple.Item2.id;

                    insertCommand.CommandText += $@"
						INSERT INTO window VALUES ({id}, '{win.windowName}', {win.nbPlots}, {(activeWindow.Equals(winTuple) ? 1 : 0)});						
					";

					foreach(PlotWindow plot in win.plots) {
						var lAxis = plot.axisLimit['l'];
						var rAxis = plot.axisLimit['r'];
						var bAxis = plot.axisLimit['b'];

                        insertCommand.CommandText += $@"
							INSERT INTO PlotInfoWindow(Name, PlotId, DataPloted, DataLoc, LeftAxisLimit, RightAxisLimit, BottomAxisLimit, windowId)
							VALUES ('{plot.plotName}', 
								{plot.plotId}, '{JsonSerializer.Serialize(plot.dataPloted.Keys)}',
								'{JsonSerializer.Serialize(plot.dataPloted.Values)}', 
								'{{{lAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + lAxis.Item2.ToString(CultureInfo.InvariantCulture)}}}',
								'{{{rAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + rAxis.Item2.ToString(CultureInfo.InvariantCulture)}}}',
								'{{{bAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + bAxis.Item2.ToString(CultureInfo.InvariantCulture)}}}',
								{id}
							);						
						";
					}
				}

				//Stocker les consoles
				foreach ((ConsoleWindow, PanelConsoleControl) cons in consoles) {
					ConsoleWindow cw = cons.Item1;
					insertCommand.CommandText += $@"
						INSERT INTO console VALUES ({cw.id}, '{cw.Name}', {cw.forceBottom}, {cw.isTimestampActive}, {(activeConsole.Equals(cons) ? 1 : 0)});						
					";
				}

				//Stocker les informations de data
				for (int i = 0 ; i < Datas.Count; i++) {
                    insertCommand.CommandText += $@"
						INSERT INTO DataInfo VALUES (
							{i},
							'{DatasName[i]}',
							{DatasColor[i].ToArgb()},
							{isDataCutomised[i]},
							'{expressions[i]}'
						);						
					";
                }



				//Stocker les variables 
				EqualizeDatas();
                for(int i = 0; i < Datas.Count; i++) {
					insertCommand.CommandText += $@"INSERT INTO [{DatasName[i]}](value) VALUES ";
                    for (int j = 0; j < timeY.Count ; j++) {
                        insertCommand.CommandText += $@"({Datas[i][j].ToString(CultureInfo.InvariantCulture)}),";
                    }
					insertCommand.CommandText = insertCommand.CommandText.Remove(insertCommand.CommandText.Length - 1);
					insertCommand.CommandText += ";";
                }

                insertCommand.CommandText += $@"INSERT INTO Time(value) VALUES ";
                for (int j = 0; j < timeY.Count; j++) {
					insertCommand.CommandText += $@"({timeY[j].ToString(CultureInfo.InvariantCulture)}),";
                }
                insertCommand.CommandText = insertCommand.CommandText.Remove(insertCommand.CommandText.Length - 1);
                insertCommand.CommandText += ";";

				Debug.WriteLine(insertCommand.CommandText);
                insertCommand.ExecuteNonQuery();
            }
        }

		public void EqualizeDatas() {
			int normalSize = timeY.Count;
			foreach (var data in Datas) {
				Debug.WriteLine(normalSize - data.Count + " valeurs ont été ajoutées");
				MakeNumberOfElemEven(data, normalSize, 0);
			}
		}

		public bool IsFileLocked(string pathFile) {
            FileInfo fichier = new FileInfo(pathFile);


            if (!fichier.Exists) return false;

            try {
                using (FileStream stream = fichier.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                    stream.Close();
                }
            } catch (IOException) {
                return true;
            }
            return false;
        }
		
		public void MakeNumberOfElemEven<T>(List<T> list, int normalSize, T valueToAdd) {
			int missingElem = normalSize - list.Count;

			if (missingElem > 0) {
				list.InsertRange(0, Enumerable.Repeat(valueToAdd, missingElem));
			}
		}
	
	}
}
