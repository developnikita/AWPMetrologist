using AWPMetrologist.Client.ServiceReference;
using AWPMetrologist.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWPMetrologist.Client
{
    public class Connection
    {
        private Connection()
        {
            string ip = IpAddressService.Ip;
            string port = IpAddressService.Port;
            _client.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://" + ip + ":" + port + "/Service"));
        }

        public async Task<List<FactoryManufacturer>> GetFactoryManufactirers()
        {
            var result = await _client.GetFactoryManufacturersJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.FactoryManufacturer>();
            }
        }

        public async Task<List<InstallationLocation>> GetInstallationLocations()
        {
            var result = await _client.GetInstallationLocationsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.InstallationLocation>();
            }
        }

        public async Task<List<MeasuredParameter>> GetMeasuredParameters()
        {
            var result = await _client.GetMeasuredParametersJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.MeasuredParameter>();
            }
        }

        public async Task<List<MSCategory>> GetMSCategories()
        {
            var result = await _client.GetMSCategoriesJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.MSCategory>();
            }
        }

        public async Task<List<MSKind>> GetMSKinds()
        {
            var result = await _client.GetMSKindsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.MSKind>();
            }
        }

        public async Task<List<RepairOrganization>> GetRepairOrganizations()
        {
            var result = await _client.GetRepairOrganizationsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.RepairOrganization>();
            }
        }

        public async Task<List<RepairReason>> GetRepairReasons()
        {
            var result = await _client.GetRepairReasonsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.RepairReason>();
            }
        }

        public async Task<List<Storage>> GetStorages()
        {
            var result = await _client.GetStoragesJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.Storage>();
            }
        }

        public async Task<List<TechnicalCondition>> GetTechnicalConditions()
        {
            var result = await _client.GetTechnicalConditionsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.TechnicalCondition>();
            }
        }

        public async Task<List<Unit>> GetUnits()
        {
            var result = await _client.GetUnitsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.Unit>();
            }
        }

        public async Task<List<VerificationMethod>> GetVerificationMethods()
        {
            var result = await _client.GetVerificationMethodsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.VerificationMethod>();
            }
        }

        public async Task<List<MeasuringSystem>> GetMeasuringSystems()
        {
            var result = await _client.GetMeasuringSystemsJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<ServiceReference.MeasuringSystem>();
            }
        }

        public async Task<List<MeasuringSystem>> GetHandbookMeasuringSystem()
        {
            var result = await _client.GetHandbookMeasuringSystemDataJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<MeasuringSystem>();
            }
        }

        public async Task<List<MeasuringSystem>> GetMeasuringSystemVerification()
        {
            var result = await _client.GetMeasuringSystemsVerificationJsonAsync();

            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<MeasuringSystem>();
            }
        }

        public async Task<bool> AddMSCategory(MSCategory category)
        {
            var result = await _client.AddMSCategoryAsync(category);

            return result;
        }

        public async Task<bool> AddFactoryManufacturer(FactoryManufacturer factory)
        {
            var result = await _client.AddFactoryManufacturerAsync(factory);

            return result;
        }

        public async Task<bool> AddInstallationLocation(InstallationLocation location)
        {
            var result = await _client.AddInstallationLocationAsync(location);

            return result;
        }

        public async Task<bool> AddMSKind(MSKind kind)
        {
            var result = await _client.AddMSKindAsync(kind);

            return result;
        }

        public async Task<bool> AddMeasuredParameter(MeasuredParameter parameter)
        {
            var result = await _client.AddMeasuredParameterAsync(parameter);

            return result;
        }

        public async Task<bool> AddRepairOrganization(RepairOrganization organization)
        {
            var result = await _client.AddRepairOrganizationAsync(organization);

            return result;
        }

        public async Task<bool> AddRepairReason(RepairReason reason)
        {
            var result = await _client.AddRepairReasonAsync(reason);

            return result;
        }

        public async Task<bool> AddStorage(Storage storage)
        {
            var result = await _client.AddStorageAsync(storage);

            return result;
        }

        public async Task<bool> AddTechnicalCondition(TechnicalCondition condition)
        {
            var result = await _client.AddTechnicalConditionAsync(condition);

            return result;
        }

        public async Task<bool> AddUnit(Unit unit)
        {
            var result = await _client.AddUnitAsync(unit);

            return result;
        }

        public async Task<bool> AddVerificationMethod(VerificationMethod method)
        {
            var result = await _client.AddVerificationMethodAsync(method);

            return result;
        }

        public async Task<bool> AddMeasuringSystem(MeasuringSystem system)
        {
            var result = await _client.AddMeasuringSystemAsync(system);

            return result;
        }

        public async Task<int> AddVerification(Verification verification)
        {
            var result = await _client.AddVerificationAsync(verification);

            return result;
        }

        public async Task<bool> DeleteMSCategory(MSCategory category)
        {
            var result = await _client.DeleteMSCategoryAsync(category);

            return result;
        }

        public async Task<bool> DeleteFactureManufacturer(FactoryManufacturer factory)
        {
            var result = await _client.DeleteFactoryManufacturerAsync(factory);

            return result;
        }

        public async Task<bool> DeleteInstallationLocation(InstallationLocation location)
        {
            var result = await _client.DeleteInstallationLocationAsync(location);

            return result;
        }

        public async Task<bool> DeleteMSKind(MSKind kind)
        {
            var result = await _client.DeleteMSKindAsync(kind);

            return result;
        }

        public async Task<bool> DeleteMeasuredParameter(MeasuredParameter parameter)
        {
            var result = await _client.DeleteMeasuredParameterAsync(parameter);

            return result;
        }

        public async Task<bool> DeleteRepairOrganization(RepairOrganization organization)
        {
            var result = await _client.DeleteRepairOrganizationAsync(organization);

            return result;
        }

        public async Task<bool> DeleteRepairReason(RepairReason reason)
        {
            var result = await _client.DeleteRepairReasonAsync(reason);

            return result;
        }

        public async Task<bool> DeleteStorage(Storage storage)
        {
            var result = await _client.DeleteStorageAsync(storage);

            return result;
        }

        public async Task<bool> DeleteTechnicalCondition(TechnicalCondition condition)
        {
            var result = await _client.DeleteTechnicalConditionAsync(condition);

            return result;
        }

        public async Task<bool> DeleteUnit(Unit unit)
        {
            var result = await _client.DeleteUnitAsync(unit);

            return result;
        }

        public async Task<bool> DeleteVerificationMethod(VerificationMethod method)
        {
            var result = await _client.DeleteVerificationMethodAsync(method);

            return result;
        }

        public async Task<bool> UpdateExploitation(Exploitation exploitation)
        {
            var result = await _client.UpdateExploitationAsync(exploitation);

            return result;
        }

        public async Task<bool> UpdateVerification(Verification verification)
        {
            var result = await _client.UpdateVerificationAsync(verification);

            return result;
        }

        public static Connection Instance
        {
            get
            {
                return _instance;
            }
        }

        private static Connection _instance = new Connection();
        private ServiceReference.ServiceClient _client = new ServiceReference.ServiceClient();
    }
}
