using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC_ {
    public static class Utils {
        public static bool IsFileLocked(string pathFile) {
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

        public static void MakeNumberOfElemEven<T>(List<T> list, int normalSize, T valueToAdd) {
            int missingElem = normalSize - list.Count;

            if (missingElem > 0) {
                list.InsertRange(0, Enumerable.Repeat(valueToAdd, missingElem));
            }
        }

        public static double IsNumberNaN(double nb) {
            if(double.IsNaN(nb) || double.IsInfinity(nb)) {
                return -1;
            }
            return nb;
        }

        public static (double, double) TupleOrMOneIfNan((double, double) nb) {
            if (double.IsInfinity(nb.Item1) || double.IsInfinity(nb.Item2) || double.IsNaN(nb.Item1) && double.IsNaN(nb.Item2)) {
                return (-1, -1);
            }
            return nb;
        }
    }
}
