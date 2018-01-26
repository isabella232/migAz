﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigAz.Core.Interface;
using MigAz.Azure.UserControls;
using MigAz.Azure.Interface;

namespace MigAz.UserControls
{
    public partial class MigAzMigrationTargetSelection : UserControl
    {
        private IMigrationSourceUserControl _IMigrationSource;

        public IMigrationSourceUserControl MigrationSource
        {
            get
            {
                return _IMigrationSource;
            }
            internal set
            {
                _IMigrationSource = value;

                label1.Visible = !(_IMigrationSource != null);
                btnAzure.Enabled = (_IMigrationSource != null);
                btnAzureStack.Enabled = (_IMigrationSource != null);
            }
        }

        public delegate void AfterMigrationTargetSelectedHandler(IMigrationTargetUserControl migrationTargetUserControl);
        public event AfterMigrationTargetSelectedHandler AfterMigrationTargetSelected;

        public MigAzMigrationTargetSelection()
        {
            InitializeComponent();
        }

        private void btnAzure_Click(object sender, EventArgs e)
        {
            AfterMigrationTargetSelected?.Invoke(new MigrationAzureTargetContext());
        }

        private void btnAzureStack_Click(object sender, EventArgs e)
        {
            AfterMigrationTargetSelected?.Invoke(null);
        }

        private void MigAzMigrationTargetSelection_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 10;
        }
    }
}
