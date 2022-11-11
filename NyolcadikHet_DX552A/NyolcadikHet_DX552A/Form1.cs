﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyolcadikHet_DX552A
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<Entities.PortfolioItem>Portfolio = new List<Entities.PortfolioItem>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new Entities.PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new Entities.PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new Entities.PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
    }
}
