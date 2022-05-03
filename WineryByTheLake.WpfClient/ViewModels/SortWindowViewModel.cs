using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineryByTheLake.Models;

namespace WineryByTheLake.WpfClient.ViewModels
{
    public class SortWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<Wine> wines;
        public RestCollection<Wine> Wines
        {
            get { return wines; }
            set { SetProperty(ref wines, value); }
        }

        public RestCollection<Wine> Reds { get; set; }
        public RestCollection<Wine> Whites { get; set; }
        public RestCollection<Wine> Roses { get; set; }

        public ICommand RedCommand { get; set; }
        public ICommand WhiteCommand { get; set; }
        public ICommand RoseCommand { get; set; }

        public SortWindowViewModel()
        {
            Reds = new RestCollection<Wine>("http://localhost:44340/", "product/red");
            Whites = new RestCollection<Wine>("http://localhost:44340/", "product/white");
            Roses = new RestCollection<Wine>("http://localhost:44340/", "product/rose");

            RedCommand = new RelayCommand(() =>
            {
                try
                {
                    Wines = Reds;
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });

            WhiteCommand = new RelayCommand(() =>
            {
                try
                {
                    Wines = Whites;
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });

            RoseCommand = new RelayCommand(() =>
            {
                try
                {
                    Wines = Roses;
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });
        }
         
    }
}
