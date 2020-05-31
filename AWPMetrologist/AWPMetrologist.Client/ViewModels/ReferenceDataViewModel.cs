using AWPMetrologist.Client.ViewModels.Dictionary;
using AWPMetrologist.Client.Views.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;

namespace AWPMetrologist.Client.ViewModels
{
    public class ReferenceDataViewModel : INotifyPropertyChanged
    {
        public void Initialize()
        {
            _itemList = new Dictionary<string, UserControl>();
            _itemList.Add("Категория", new CategoryView());
            _itemList.Add("Завод-производитель", new FactoryManufacturerView());
            _itemList.Add("Место установки", new InstallationLocationView());
            _itemList.Add("Вид измерителя", new KindView());
            _itemList.Add("Измеряемый параметр", new MeasuredParameterView());
            _itemList.Add("Ремонтная организация", new RepairOrganizationView());
            _itemList.Add("Причина ремонта", new RepairReasonView());
            _itemList.Add("Место хранения", new StorageView());
            _itemList.Add("Техническое состояние", new TechnicalConditionView());
            _itemList.Add("Единицы измерения", new UnitView());
            _itemList.Add("Метод поверки", new VerificationMethodView());
        }

        public void ListItemClick(object sender, ItemClickEventArgs args)
        {
            string key = (string)args.ClickedItem;
            _selectedItem = key;
            UserControl value;
            _itemList.TryGetValue(key, out value);
            Control = value;
            Type type = value.GetType();
            switch (type.Name)
            {
                case "CategoryView":
                    _controlViewModel = (value as CategoryView).ViewModel;
                    break;
                case "FactoryManufacturerView":
                    _controlViewModel = (value as FactoryManufacturerView).ViewModel;
                    break;
                case "InstallationLocationView":
                    _controlViewModel = (value as InstallationLocationView).ViewModel;
                    break;
                case "KindView":
                    _controlViewModel = (value as KindView).ViewModel;
                    break;
                case "MeasuredParameterView":
                    _controlViewModel = (value as MeasuredParameterView).ViewModel;
                    break;
                case "RepairOrganizationView":
                    _controlViewModel = (value as RepairOrganizationView).ViewModel;
                    break;
                case "RepairReasonView":
                    _controlViewModel = (value as RepairReasonView).ViewModel;
                    break;
                case "StorageView":
                    _controlViewModel = (value as StorageView).ViewModel;
                    break;
                case "TechnicalConditionView":
                    _controlViewModel = (value as TechnicalConditionView).ViewModel;
                    break;
                case "UnitView":
                    _controlViewModel = (value as UnitView).ViewModel;
                    break;
                case "VerificationMethodView":
                    _controlViewModel = (value as VerificationMethodView).ViewModel;
                    break;
            };
        }

        public IList<string> ItemList
        {
            get
            {
                return _itemList.Keys.ToList();
            }

            private set
            {
            }
        }

        public UserControl Control
        {
            get
            {
                return _selectedUserContorl;
            }

            set
            {
                if (_selectedUserContorl != value)
                {
                    _selectedUserContorl = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Control)));
                }
            }
        }

        public CommandViewModel ControlViewModel 
        { 
            get
            {
                return _controlViewModel;
            }

            set
            {

            }
        }

        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedItem;
        private CommandViewModel _controlViewModel;
        private UserControl _selectedUserContorl;
        private Dictionary<string, UserControl> _itemList;
    }
}
