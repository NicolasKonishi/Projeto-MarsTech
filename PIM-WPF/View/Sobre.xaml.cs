﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIM_WPF.View
{
    /// <summary>
    /// Interação lógica para Sobre.xam
    /// </summary>
    public partial class Sobre : UserControl
    {
        public Sobre()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow
        {
            get => default;
            set
            {
            }
        }
    }
}
