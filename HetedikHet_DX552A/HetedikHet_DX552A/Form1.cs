using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HetedikHet_DX552A
{
    public partial class Form1 : Form
    {
        private List<Entities.Ball> _balls = new List<Entities.Ball>();

        private Entities.BallFactory _factory;

        public Entities.BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }


        public Form1()
        {
            InitializeComponent();
            Factory = new Entities.BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);

        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var b in _balls)
            {
                b.MoveBall();
                if (b.Left > maxPosition)
                {
                    maxPosition = b.Left;
                }
                if (maxPosition > 1000)
                {
                    var oldestBall = _balls[0];
                    mainPanel.Controls.Remove(oldestBall);
                    _balls.Remove(oldestBall);
                }
            }
        }
    }
}
