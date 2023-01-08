using Pos.Entities;
using Pos.Entities.PosStates;
using PosUI.Interfaces;
using System.Windows;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashForm : Window, ISetViewModel
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        public PosStateEnum PosStateEnum => PosStateEnum.InitState;

        public void SetViewModel(TransferModel model)
        {
           
        }
    }
}
