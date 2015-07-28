using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Mdk.Domain;
using Mdk.DependencyResolution;

namespace Mdk.Ui
{
    // this form is a simple UI for testing the algorithm.  I'm not proud of it, 
    //  but there comes a point when it's done enough.  In hindsight, it probably 
    //  would have been easier to use a web project of some kind.  
    public partial class Form1 : Form
    {
        ICandidateService _service;

        public Form1()
        {
            InitializeComponent();
            var builder = Initializer.Initialize();
            var container = builder.Build();
            var scope = container.BeginLifetimeScope();
            _service = scope.Resolve<ICandidateService>();

        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            tbOutput.Clear();
            var candidates = _service.GetCandidates(tbInput.Text);
            var sb = new StringBuilder();
            foreach (var candidate in candidates)
            {
                sb.AppendLine(candidate.Confidence.ToString() + " " + candidate.Word);
            }
            tbOutput.Text = sb.ToString();
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            _service.Train(tbInput.Text);
            tbInput.Clear();
        }
    }
}
