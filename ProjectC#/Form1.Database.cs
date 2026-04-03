using DynamicExpresso;
using OpenTK;
using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 : Form {
		private void ExportConfig(object sender, EventArgs e) {
			SaveFileDialog FileDialog = new SaveFileDialog();
			FileDialog.Filter = "Fichier SQLite (*.db)|*.db|Tous les fichiers (*.*)|*.*";
			FileDialog.Title = "Exporter le projet";
			FileDialog.FileName = "Project Plotter " + DateTime.Now.ToString("dd-MM-yy") + ".db";

			if (FileDialog.ShowDialog() != DialogResult.OK) return;

			if (Utils.IsFileLocked(FileDialog.FileName)) {
                MessageBox.Show("Le fichier est déja\n utilisé par un\nautre processus", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
            }
			if (File.Exists(FileDialog.FileName)) {
				File.Delete(FileDialog.FileName);
			}
			CreateDataBase(FileDialog.FileName);

			MessageBox.Show("Projet Sauvegardé\navec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void LoadConfig(object sender, EventArgs e) {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "Fichier SQLite (*.db)|*.db|Tous les fichiers (*.*)|*.*";
            FileDialog.Title = "Importer un projet";
			FileDialog.FileName = "";

            if (FileDialog.ShowDialog() != DialogResult.OK) return;

			SetPauseState(true);
			LoadDatabase(FileDialog.FileName);
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
						(double, double) lAxis = Utils.TupleOrMOneIfNan(plot.axisLimit['l']);
                        (double, double) rAxis = Utils.TupleOrMOneIfNan(plot.axisLimit['r']); ;
                        (double, double) bAxis = Utils.TupleOrMOneIfNan(plot.axisLimit['b']); ;

                        insertCommand.CommandText += $@"
							INSERT INTO PlotInfoWindow(Name, PlotId, DataPloted, DataLoc, LeftAxisLimit, RightAxisLimit, BottomAxisLimit, windowId)
							VALUES ('{plot.plotName}', 
								{plot.plotId}, '{JsonSerializer.Serialize(plot.dataPloted.Keys)}',
								'{JsonSerializer.Serialize(plot.dataPloted.Values)}', 
								'[{lAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + lAxis.Item2.ToString(CultureInfo.InvariantCulture)}]',
								'[{rAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + rAxis.Item2.ToString(CultureInfo.InvariantCulture)}]',
								'[{bAxis.Item1.ToString(CultureInfo.InvariantCulture) + "," + bAxis.Item2.ToString(CultureInfo.InvariantCulture)}]',
								{id}
							);						
						";
					}
				}

				//Stocker les consoles
				foreach ((ConsoleWindow, PanelConsoleControl) cons in consoles) {
					ConsoleWindow cw = cons.Item1;
					insertCommand.CommandText += $@"
						INSERT INTO console VALUES ({cw.id}, '{cw.getName()}', {cw.forceBottom}, {cw.isTimestampActive}, {(activeConsole.Equals(cons) ? 1 : 0)});						
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

				if(timeY.Count == 0 || Datas.Count == 0) {
                    insertCommand.ExecuteNonQuery();
					return;
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

                insertCommand.ExecuteNonQuery();
            }
        }

		private void LoadDatabase(string path) {
			using (var connection = new SQLiteConnection($"Data Source={path}")) {
				connection.Open();
				ClearAllData();
				ClearAllWindows();

                //Construction des consoles 
                SQLiteCommand consoleCommand = connection.CreateCommand();
				consoleCommand.CommandText = @"SELECT Id, Name, IsForcedBottom, IsTimeStampActive, IsSelected FROM console ORDER BY Id;";
                using (var reader = consoleCommand.ExecuteReader()) {
                    while (reader.Read()) {
						CreateNewConsole(reader.GetString(1), reader.GetBoolean(2), reader.GetBoolean(3));
						if(reader.GetBoolean(4)) SelectConsole(reader.GetInt32(0));

                    }
                }

                //Reconstruction des infos des datas
                SQLiteCommand dataInfoCommand = connection.CreateCommand();
				dataInfoCommand.CommandText = @"SELECT Id, Name, Color, IsDataCustomised, Expression FROM DataInfo ORDER BY Id;";
                using (var reader = dataInfoCommand.ExecuteReader()) {
					while (reader.Read()) {
						string name = reader.GetString(1);
						Color color = Color.FromArgb(reader.GetInt32(2));
						string expression = reader.GetString(4);

						if (reader.GetInt32(3) > 0) {
							AddNewCustomData(name, color, expression);
						} else {
							AddNewData(name, color);
						}
                    }
				}

				int windowSelectedId = -1;
                //Reconstruction des windows
                SQLiteCommand windowCommand = connection.CreateCommand();
				windowCommand.CommandText = @"SELECT Id, Name, IsSelected FROM window ORDER BY Id";
                using (var reader = windowCommand.ExecuteReader()) {
					while (reader.Read()) {
						CreateNewWindow(reader.GetString(1));
						if (reader.GetBoolean(2)) windowSelectedId = reader.GetInt32(0);

                    }
                }

                //Reconstruction des plots
                SQLiteCommand plotCommand = connection.CreateCommand();
                plotCommand.CommandText = @"SELECT Id, Name, PlotId, DataPloted, DataLoc, LeftAxisLimit, RightAxisLimit, BottomAxisLimit, windowId FROM PlotInfoWindow ORDER BY Id";
                using (var reader = plotCommand.ExecuteReader()) {
					while (reader.Read()) {
						PlotWindow pw = new PlotWindow(reader.GetString(1), reader.GetInt32(2));
						Dictionary<int, char> plots = new Dictionary<int, char>();
						int[] plotIds = JsonSerializer.Deserialize<int[]>(reader.GetString(3));
						char[] plotLocs = JsonSerializer.Deserialize<char[]>(reader.GetString(4));
						for (int i = 0; i < plotIds.Length; i++) {
							plots.Add(plotIds[i], plotLocs[i]);
						}


						double[] leftAxis = JsonSerializer.Deserialize<double[]>(reader.GetString(5));
                        double[] rightAxis = JsonSerializer.Deserialize<double[]>(reader.GetString(6));
                        double[] bottomAxis = JsonSerializer.Deserialize<double[]>(reader.GetString(7));

						if (leftAxis[0] != -1) pw.axisLimit.Add('l', (leftAxis[0], leftAxis[1]));
                        if (rightAxis[0] != -1) pw.axisLimit.Add('r', (rightAxis[0], rightAxis[1]));
                        if (bottomAxis[0] != -1) pw.axisLimit.Add('b', (bottomAxis[0], bottomAxis[1]));

                        pw.dataPloted = plots;
						windows[reader.GetInt32(8)].Item1.plots.Add(pw);
					}
                }

                //Ajout des données
                SQLiteCommand dataValuesCommand = connection.CreateCommand();
                for(int dataId = 0; dataId < Datas.Count; dataId++) {
                    dataValuesCommand.CommandText = $@"SELECT Id, Value FROM ""{DatasName[dataId]}"" ORDER BY Id";
                    using (var reader = dataValuesCommand.ExecuteReader()) {
                        while (reader.Read()) {
							Datas[dataId].Add(reader.GetFloat(1));
                        }
                    }
                }
                dataValuesCommand.CommandText = $@"SELECT Id, Value FROM ""Time"" ORDER BY Id";
                using (var reader = dataValuesCommand.ExecuteReader()) {
					while (reader.Read()) {
                        timeY.Add(reader.GetFloat(1));
                    }
                }
				millisOffset = timeY[timeY.Count - 1];
				millis.Reset();

				if(windowSelectedId != -1) selectWindow(windowSelectedId);
                UpdateDatasPanels();
            }
		}

		public void EqualizeDatas() {
			int normalSize = timeY.Count;
			foreach (var data in Datas) {
				Debug.WriteLine(normalSize - data.Count + " valeurs ont été ajoutées");
				Utils.MakeNumberOfElemEven(data, normalSize, 0);
			}
		}

		private void ClearAllData() {
			for(int i = 0; i < Datas.Count; i++) {
				DeleteVarFromPlots(i);
            }

			Datas.Clear();
			timeY.Clear();
            DatasName.Clear();
            DatasColor.Clear();
            isDataCutomised.Clear();
            expressions.Clear();
            functions.Clear();
            datasParameters.Clear();
            DatasPanels.Clear();
            CustomsDatasPanels.Clear();
			DataFromPlot.Clear();
			
            FlowVarPanel.Controls.Clear();
        }

		private void ClearAllWindows() {
            windows.Clear();
            consoles.Clear();
            FlowLayoutWindow.Controls.Clear();
        }
	}
}
