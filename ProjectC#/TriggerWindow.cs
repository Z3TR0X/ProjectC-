using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class TriggerWindow : Form {
        public bool triggerValueNTime = false; //true = value, false = time
        public float Value = 0;
        public int stateOperation = 0;
        public string dataName = "";

        public TriggerWindow(string[] dataNames) {
            InitializeComponent();
            DataNameCB.DataSource = dataNames;
        }

        private void OkButton_Click(object sender, EventArgs e) {
            if (triggerValueNTime) {
                dataName = (string) DataNameCB.SelectedItem;
                Value = (float) ValVal.Value;
                switch (comboBox1.SelectedItem) {
                    case ">":
                        stateOperation = 1;
                        break;
                    case "<":
                        stateOperation = 2;
                        break;
                    case ">=":
                        stateOperation = 3;
                        break;
                    case "<=":
                        stateOperation = 4;
                        break;
                    default:
                    case "=":
                        stateOperation = 0;
                        break;
                }
            } else {
                Value = (float) TimeVal.Value;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ValueCheck_CheckedChanged(object sender, EventArgs e) {
            if (ValueCheck.Checked) TimeCheck.Checked = false;
            triggerValueNTime = true;
        }

        private void TimeCheck_CheckedChanged(object sender, EventArgs e) {
            if(TimeCheck.Checked) ValueCheck.Checked = false;
            triggerValueNTime = false;
        }
    }
}
