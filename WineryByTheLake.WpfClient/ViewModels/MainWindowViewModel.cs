using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WineryByTheLake.Models;
using WineryByTheLake.WpfClient.Services;

namespace WineryByTheLake.WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        /*############################## WINE ##############################*/

        public RestCollection<Wine> Wines { get; set; }

        private Wine selectedWine;

        public Wine SelectedWine
        {
            get { return selectedWine; }
            set
            {
                if (value != null)
                {
                    selectedWine = new Wine()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Price = value.Price,
                        Color = value.Color,
                        Sweetness = value.Sweetness,
                        SupplierID = value.SupplierID
                    };
                    OnPropertyChanged();
                    (DeleteWineCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateWineCommand { get; set; }
        public ICommand DeleteWineCommand { get; set; }
        public ICommand UpdateWineCommand { get; set; }

        /*############################## SUPPLIER ##############################*/

        public RestCollection<Supplier> Suppliers { get; set; }

        private Supplier selectedSupplier;

        public Supplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                if (value != null)
                {
                    selectedSupplier = new Supplier()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        RegionID = value.RegionID
                    };
                    OnPropertyChanged();
                    (DeleteSupplierCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSupplierCommand { get; set; }
        public ICommand UpdateSupplierCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }
        public ICommand SortWineCommand { get; set; }

        /*############################## REGION ##############################*/

        public RestCollection<Region> Regions { get; set; }

        private Region selectedRegion;

        public Region SelectedRegion
        {
            get { return selectedRegion; }
            set
            {
                if (value != null)
                {
                    selectedRegion = new Region()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteRegionCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateRegionCommand { get; set; }
        public ICommand UpdateRegionCommand { get; set; }
        public ICommand DeleteRegionCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<ISortService>()) //ha design módban vagyunk, akkor null a konstruktor paramétere (design rész miatt),  ha nem, akkor egy IArmyLogic implementáció
        {

        }

        public MainWindowViewModel(ISortService service)
        {
            if (!IsInDesignMode)
            {
                /*############################## WINE ##############################*/
                Wines = new RestCollection<Wine>("http://localhost:44340/", "wine", "hub");
                CreateWineCommand = new RelayCommand(() =>
                {
                    Wines.Add(new Wine()
                    {
                        Name = SelectedWine.Name,
                        Price = SelectedWine.Price,
                        Color = SelectedWine.Color,
                        Sweetness = SelectedWine.Sweetness,
                        Supplier = SelectedSupplier,
                        SupplierID = SelectedSupplier.Id
                    });
                });

                UpdateWineCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Wines.Update(SelectedWine);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteWineCommand = new RelayCommand(() =>
                {
                    Wines.Delete(SelectedWine.Id);
                },
                () =>
                {
                    return SelectedWine != null;
                });

                SortWineCommand = new RelayCommand(() =>
                {
                    service.Sort();
                });

                SelectedWine = new Wine();

                /*############################## SUPPLIER ##############################*/
                Suppliers = new RestCollection<Supplier>("http://localhost:44340/", "supplier", "hub");
                CreateSupplierCommand = new RelayCommand(() =>
                {
                    Suppliers.Add(new Supplier()
                    {
                        Name = SelectedSupplier.Name,
                        Region = SelectedRegion,
                        RegionID = SelectedRegion.Id
                    });
                });

                UpdateSupplierCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Suppliers.Update(SelectedSupplier);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSupplierCommand = new RelayCommand(() =>
                {
                    Suppliers.Delete(SelectedSupplier.Id);
                },
                () =>
                {
                    return SelectedSupplier != null;
                });

                SelectedSupplier = new Supplier();

                /*############################## REGION ##############################*/
                Regions = new RestCollection<Region>("http://localhost:44340/", "region", "hub");
                CreateRegionCommand = new RelayCommand(() =>
                {
                    Regions.Add(new Region()
                    {
                        Name = SelectedRegion.Name
                    });
                });

                UpdateRegionCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Regions.Update(SelectedRegion);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRegionCommand = new RelayCommand(() =>
                {
                    Regions.Delete(SelectedRegion.Id);
                },
                () =>
                {
                    return SelectedRegion != null;
                });

                SelectedRegion = new Region();
            }
        }
    }
}
