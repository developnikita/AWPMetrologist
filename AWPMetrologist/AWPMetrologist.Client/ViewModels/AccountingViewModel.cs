using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class AccountingViewModel
    {
        public AccountingViewModel()
        {
        }

        public void Initialize()
        {
            _ms = new ServiceReference.MeasuringSystem();
            _ms.Exploitation = new ServiceReference.Exploitation();
            //_ms.Exploitation.Verification = new ServiceReference.Verification();
            //_ms.Exploitation.Repair = new ServiceReference.Repair();
            _ms.Measuring = new ServiceReference.Measuring();
            _categories = new List<ServiceReference.MSCategory>();
            _factories = new List<ServiceReference.FactoryManufacturer>();
            _units = new List<ServiceReference.Unit>();
            _kinds = new List<ServiceReference.MSKind>();
            _measuredParameters = new List<ServiceReference.MeasuredParameter>();
            _methods = new List<ServiceReference.VerificationMethod>();
            _locations = new List<ServiceReference.InstallationLocation>();
            _storages = new List<ServiceReference.Storage>();
            _repairOrganizations = new List<ServiceReference.RepairOrganization>();
            _repairReasons = new List<ServiceReference.RepairReason>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var categories = await Connection.Instance.GetMSCategories();
            _categories.Clear();
            foreach (ServiceReference.MSCategory c in categories)
            {
                _categories.Add(c);
            }
            var factories = await Connection.Instance.GetFactoryManufactirers();
            _factories.Clear();
            foreach (ServiceReference.FactoryManufacturer f in factories)
            {
                _factories.Add(f);
            }
            var units = await Connection.Instance.GetUnits();
            _units.Clear();
            foreach (ServiceReference.Unit u in units)
            {
                _units.Add(u);
            }
            var kinds = await Connection.Instance.GetMSKinds();
            _kinds.Clear();
            foreach (ServiceReference.MSKind k in kinds)
            {
                _kinds.Add(k);
            }
            var parameters = await Connection.Instance.GetMeasuredParameters();
            _measuredParameters.Clear();
            foreach (ServiceReference.MeasuredParameter p in parameters)
            {
                _measuredParameters.Add(p);
            }
            var methods = await Connection.Instance.GetVerificationMethods();
            _methods.Clear();
            foreach (ServiceReference.VerificationMethod m in methods)
            {
                _methods.Add(m);
            }
            var locations = await Connection.Instance.GetInstallationLocations();
            _locations.Clear();
            foreach (ServiceReference.InstallationLocation l in locations)
            {
                _locations.Add(l);
            }
            var storages = await Connection.Instance.GetStorages();
            _storages.Clear();
            foreach (ServiceReference.Storage s in storages)
            {
                _storages.Add(s);
            }
            var organizations = await Connection.Instance.GetRepairOrganizations();
            _repairOrganizations.Clear();
            foreach (ServiceReference.RepairOrganization o in organizations)
            {
                _repairOrganizations.Add(o);
            }
            var reasons = await Connection.Instance.GetRepairReasons();
            _repairReasons.Clear();
            foreach (ServiceReference.RepairReason r in reasons)
            {
                _repairReasons.Add(r);
            }
        }

        public async void Save(object sender, RoutedEventArgs args)
        {
            var result = Connection.Instance.AddMeasuringSystem(_ms);
        }

        public List<ServiceReference.MSCategory> Categories
        {
            get
            {
                return _categories;
            }
            private set { }
        }

        public List<ServiceReference.FactoryManufacturer> Factories
        {
            get
            {
                return _factories;
            }
            private set { }
        }

        public List<ServiceReference.Unit> Units
        {
            get
            {
                return _units;
            }
            private set { }
        }

        public List<ServiceReference.MSKind> Kinds
        {
            get
            {
                return _kinds;
            }
            private set { }
        }

        public List<ServiceReference.MeasuredParameter> Parameters
        {
            get
            {
                return _measuredParameters;
            }

            private set { }
        }

        public List<ServiceReference.VerificationMethod> Methods
        {
            get
            {
                return _methods;
            }
            private set { }
        }

        public List<ServiceReference.InstallationLocation> Locations
        {
            get
            {
                return _locations;
            }
            private set { }
        }

        public List<ServiceReference.Storage> Storages
        {
            get
            {
                return _storages;
            }
            private set { }
        }

        public List<ServiceReference.RepairOrganization> Organizations
        {
            get
            {
                return _repairOrganizations;
            }
            private set { }
        }

        public List<ServiceReference.RepairReason> Reasons
        {
            get
            {
                return _repairReasons;
            }

            private set { }
        }

        public ServiceReference.MeasuringSystem MS
        {
            get
            {
                return _ms;
            }

            set
            {
                if (_ms != value)
                {
                    _ms = value;
                }
            }
        }

        private ServiceReference.MeasuringSystem _ms;
        private List<ServiceReference.MSCategory> _categories;
        private List<ServiceReference.FactoryManufacturer> _factories;
        private List<ServiceReference.Unit> _units;
        private List<ServiceReference.MSKind> _kinds;
        private List<ServiceReference.MeasuredParameter> _measuredParameters;
        private List<ServiceReference.VerificationMethod> _methods;
        private List<ServiceReference.InstallationLocation> _locations;
        private List<ServiceReference.Storage> _storages;
        private List<ServiceReference.RepairOrganization> _repairOrganizations;
        private List<ServiceReference.RepairReason> _repairReasons;
    }
}
