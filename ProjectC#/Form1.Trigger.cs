using DynamicExpresso;
using System;
using System.Drawing;

namespace ProjectC_ {
    public partial class Form1 {
        int isTriggerActive = 0; //0 = pas de trigger, 1 = value, 2 = time

        public void OpenTriggerForm(object sender, EventArgs e) {
            TriggerWindow triggerWindow = new TriggerWindow(DatasName.ToArray());
            if (triggerWindow.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            SetPauseState(true);
            PausContButton.StateCommon.Back.Color1 = Color.FromArgb(1, 23, 84);
            PausContButton.StateTracking.Back.Color1 = Color.FromArgb(1, 39, 145);
            PausContButton.StatePressed.Back.Color1 = Color.FromArgb(0, 46, 173);
            PausContButton.OverrideDefault.Back.Color1 = Color.FromArgb(1, 23, 84);
            PausContButton.Values.Text = "";
            if (triggerWindow.triggerValueNTime) {
                SetValueTrigger(triggerWindow.stateOperation, triggerWindow.dataName, triggerWindow.Value);
            } else {
                SetTimeTrigger(triggerWindow.Value);
            }
        }

        //Pour plus de simplicité, on réduit les opérations a des états : 0 =, 1 >, 2 <, 3 >=, 4 <=
        int triggerDataId = -1;
        Func<double, bool> trigger = null;
        public void SetValueTrigger(int state, string nameOfData, float value) {
            Interpreter interpreter = new Interpreter();
            switch (state) {
                case 1:
                    trigger = param => param > value;
                    break;
                case 2:
                    trigger = param => param < value;
                    break;
                case 3:
                    trigger = param => param >= value;
                    break;
                case 4:
                    trigger = param => param <= value;
                    break;
                default:
                    trigger = param => param == value;
                    break;

            }
            for (int i = 0; i < Datas.Count; i++) {
                if (DatasName[i] == nameOfData) {
                    triggerDataId = i;
                }
            }
            if (triggerDataId != -1) {
                isTriggerActive = 1;
            } else {
                isTriggerActive = 0;
            }
        }


        float targetTriggerTime = 0;
        public void SetTimeTrigger(float time) {
            targetTriggerTime = time;
            timeForTrigger.Restart();
            isTriggerActive = 2;
        }
    }
}
