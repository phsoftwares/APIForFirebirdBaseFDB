using FirebirdSql.Data.FirebirdClient;
using FirstApplicationAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomer")]
        public List<CustomerDTO> Get()
        {
            List<CustomerDTO> customerRegisterList = new List<CustomerDTO>();
            FirebirdDBConnection dbConnection = new FirebirdDBConnection();
            dbConnection.OpenConnection();

            // Replace this query with your actual SELECT query
            string selectQuery = "SELECT * FROM C000007";

            FbDataReader reader = dbConnection.ExecuteSelectQuery(selectQuery);

            if (reader != null)
            {
                while (reader.Read())
                {
                    int customerId = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    string customerFullName = reader.GetString(reader.GetOrdinal("NOME"));
                    string customerName = reader.GetString(reader.GetOrdinal("APELIDO"));
                    string customerAddress = reader.GetString(reader.GetOrdinal("ENDERECO"));
                    string customerNeighborhood = reader.GetString(reader.GetOrdinal("BAIRRO"));
                    string customerCity = reader.GetString(reader.GetOrdinal("CIDADE"));
                    string customerState = reader.GetString(reader.GetOrdinal("UF"));
                    string customerZipCode = reader.GetString(reader.GetOrdinal("CEP"));
                    string customerComplement = reader.GetString(reader.GetOrdinal("COMPLEMENTO"));
                    int? customerResidence = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("MORADIA")))
                    {
                        customerResidence = reader.GetInt32(reader.GetOrdinal("MORADIA"));
                    }
                    int? customerType = 1;

                    if (!reader.IsDBNull(reader.GetOrdinal("TIPO")))
                    {
                        customerType = reader.GetInt32(reader.GetOrdinal("TIPO"));
                    }

                    int? customerStatus = 0;
                    if (!reader.IsDBNull(reader.GetOrdinal("SITUACAO")))
                    {
                        customerStatus = reader.GetInt32(reader.GetOrdinal("SITUACAO"));
                    }

                    string customerPhone1 = reader.GetString(reader.GetOrdinal("TELEFONE1"));
                    string customerPhone2 = reader.GetString(reader.GetOrdinal("TELEFONE2"));
                    string customerPhone3 = reader.GetString(reader.GetOrdinal("TELEFONE3"));
                    string customerCellphone = reader.GetString(reader.GetOrdinal("CELULAR"));
                    string customerEmail = reader.GetString(reader.GetOrdinal("EMAIL"));
                    string customerRG = reader.GetString(reader.GetOrdinal("RG"));
                    string customerCPF = reader.GetString(reader.GetOrdinal("CPF"));
                    string customerParentage = reader.GetString(reader.GetOrdinal("FILIACAO"));
                    string customerMaritalStatus = reader.GetString(reader.GetOrdinal("ESTADOCIVIL"));
                    string customerSpouse = reader.GetString(reader.GetOrdinal("CONJUGE"));
                    string customerProfession = reader.GetString(reader.GetOrdinal("PROFISSAO"));
                    string customerCompany = reader.GetString(reader.GetOrdinal("EMPRESA"));

                    long? customerIncome = 0;
                    if (!reader.IsDBNull(reader.GetOrdinal("RENDA")))
                    {
                        customerIncome = reader.GetInt64(reader.GetOrdinal("RENDA"));
                    }
                    long? customerLimit = 0;
                    if (!reader.IsDBNull(reader.GetOrdinal("LIMITE")))
                    {
                        customerIncome = reader.GetInt64(reader.GetOrdinal("LIMITE"));
                    }

                    string customerSalespersonCode = reader.GetString(reader.GetOrdinal("CODVENDEDOR"));
                    DateTime? customerRegistrationDate = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA_CADASTRO")))
                    {
                        customerRegistrationDate = reader.GetDateTime(reader.GetOrdinal("DATA_CADASTRO"));
                    }
                    DateTime? customerLastPurchaseDate = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA_ULTIMACOMPRA")))
                    {
                        customerRegistrationDate = reader.GetDateTime(reader.GetOrdinal("DATA_ULTIMACOMPRA"));
                    }
                    string customerBirthdate = reader.GetString(reader.GetOrdinal("NASCIMENTO"));
                    string customerRegionCode = reader.GetString(reader.GetOrdinal("CODREGIAO"));
                    string customerAgreementCode = reader.GetString(reader.GetOrdinal("CODCONVENIO"));
                    string customerUserCode = reader.GetString(reader.GetOrdinal("CODUSUARIO"));
                    string customerNumber = reader.GetString(reader.GetOrdinal("NUMERO"));
                    string customerRgOrgan = reader.GetString(reader.GetOrdinal("RG_ORGAO"));
                    string customerRgState = reader.GetString(reader.GetOrdinal("RG_ESTADO"));
                    DateTime? customerRgIssuanceDate = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("RG_EMISSAO")))
                    {
                        customerRegistrationDate = reader.GetDateTime(reader.GetOrdinal("RG_EMISSAO"));
                    }
                    string customerGender = reader.GetString(reader.GetOrdinal("SEXO"));
                    DateTime? customerForecast = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("PREVISAO")))
                    {
                        customerRegistrationDate = reader.GetDateTime(reader.GetOrdinal("PREVISAO"));
                    }
                    string customerCNAE = reader.GetString(reader.GetOrdinal("CNAE"));
                    string customerIBGEMunicipalityCode = reader.GetString(reader.GetOrdinal("COD_MUNICIPIO_IBGE"));
                    string customerIBGE = reader.GetString(reader.GetOrdinal("IBGE"));
                    string customerPantsSize = reader.GetString(reader.GetOrdinal("TAMANHO_CALCA"));
                    string customerBlouseSize = reader.GetString(reader.GetOrdinal("TAMANHO_BLUSA"));
                    string customerShoeSize = reader.GetString(reader.GetOrdinal("TAMANHO_SAPATO"));
                    string customerCorrespondenceAddress = reader.GetString(reader.GetOrdinal("CORRESP_ENDERECO"));
                    string customerCorrespondenceNeighborhood = reader.GetString(reader.GetOrdinal("CORRESP_BAIRRO"));
                    string customerCorrespondenceCity = reader.GetString(reader.GetOrdinal("CORRESP_CIDADE"));
                    string customerCorrespondenceState = reader.GetString(reader.GetOrdinal("CORRESP_UF"));
                    string customerCorrespondenceZipCode = reader.GetString(reader.GetOrdinal("CORRESP_CEP"));
                    string customerCorrespondenceComplement = reader.GetString(reader.GetOrdinal("CORRESP_COMPLEMENTO"));
                    string customerProducerRg = reader.GetString(reader.GetOrdinal("RG_PRODUTOR"));
                    string customerResponsible1Name = reader.GetString(reader.GetOrdinal("RESP1_NOME"));
                    string customerResponsible1CPF = reader.GetString(reader.GetOrdinal("RESP1_CPF"));
                    string customerResponsible1RG = reader.GetString(reader.GetOrdinal("RESP1_RG"));
                    string customerResponsible1Profession = reader.GetString(reader.GetOrdinal("RESP1_PROFISSAO"));
                    string customerResponsible1MaritalStatus = reader.GetString(reader.GetOrdinal("RESP1_ESTADO_CIVIL"));
                    string customerResponsible1Address = reader.GetString(reader.GetOrdinal("RESP1_ENDERECO"));
                    string customerResponsible1Neighborhood = reader.GetString(reader.GetOrdinal("RESP1_BAIRRO"));
                    string customerResponsible1City = reader.GetString(reader.GetOrdinal("RESP1_CIDADE"));
                    string customerResponsible1State = reader.GetString(reader.GetOrdinal("RESP1_UF"));
                    string customerResponsible1ZipCode = reader.GetString(reader.GetOrdinal("RESP1_CEP"));
                    string customerResponsible2Name = reader.GetString(reader.GetOrdinal("RESP2_NOME"));
                    string customerResponsible2CPF = reader.GetString(reader.GetOrdinal("RESP2_CPF"));
                    string customerResponsible2RG = reader.GetString(reader.GetOrdinal("RESP2_RG"));
                    string customerResponsible2Profession = reader.GetString(reader.GetOrdinal("RESP2_PROFISSAO"));
                    string customerResponsible2MaritalStatus = reader.GetString(reader.GetOrdinal("RESP2_ESTADO_CIVIL"));
                    string customerResponsible2Address = reader.GetString(reader.GetOrdinal("RESP2_ENDERECO"));
                    string customerResponsible2Neighborhood = reader.GetString(reader.GetOrdinal("RESP2_BAIRRO"));
                    string customerResponsible2City = reader.GetString(reader.GetOrdinal("RESP2_CIDADE"));
                    string customerResponsible2State = reader.GetString(reader.GetOrdinal("RESP2_UF"));
                    string customerResponsible2ZipCode = reader.GetString(reader.GetOrdinal("RESP2_CEP"));
                    string customerPhoto = reader.GetString(reader.GetOrdinal("FOTO"));
                    string customerPaymentCondition = reader.GetString(reader.GetOrdinal("CONDPGTO"));
                    string customerIEType = reader.GetString(reader.GetOrdinal("TIPO_IE"));
                    string customerFinalConsumer = reader.GetString(reader.GetOrdinal("CONSUMIDOR_FINAL"));
                    string customerBranchCode = reader.GetString(reader.GetOrdinal("CODFILIAL"));

                    CustomerDTO customer = new CustomerDTO();
                    customer.LegacyId = customerId;
                    customer.Address = customerAddress;
                    customer.Nickname = customerName;
                    customer.FullName = customerFullName;
                    customer.Complement = customerComplement;
                    customer.Residence = customerResidence;
                    customer.Type = customerType;
                    customer.Status = customerStatus;
                    customer.Phone1 = customerPhone1;
                    customer.Phone2 = customerPhone2;
                    customer.Phone3 = customerPhone3;
                    customer.Cellphone = customerCellphone;
                    customer.Email = customerEmail;
                    customer.RG = customerRG;
                    customer.CPF = customerCPF;
                    customer.Parentage = customerParentage;
                    customer.MaritalStatus = customerMaritalStatus;
                    customer.Spouse = customerSpouse;
                    customer.Profession = customerProfession;
                    customer.Company = customerCompany;
                    customer.Income = customerIncome;
                    customer.Limit = customerLimit;
                    customer.SalespersonCode = customerSalespersonCode;
                    customer.RegistrationDate = customerRegistrationDate;
                    customer.LastPurchaseDate = customerLastPurchaseDate;
                    customer.Birthdate = customerBirthdate;
                    customer.RegionCode = customerRegionCode;
                    customer.AgreementCode = customerAgreementCode;
                    customer.UserCode = customerUserCode;
                    customer.Number = customerNumber;
                    customer.RgOrgan = customerRgOrgan;
                    customer.RgState = customerRgState;
                    customer.RgIssuanceDate = customerRgIssuanceDate;
                    customer.Gender = customerGender;
                    customer.Forecast = customerForecast;
                    customer.CNAE = customerCNAE;
                    customer.IBGEMunicipalityCode = customerIBGEMunicipalityCode;
                    customer.IBGE = customerIBGE;
                    customer.PantsSize = customerPantsSize;
                    customer.BlouseSize = customerBlouseSize;
                    customer.ShoeSize = customerShoeSize;
                    customer.CorrespondenceAddress = customerCorrespondenceAddress;
                    customer.CorrespondenceNeighborhood = customerCorrespondenceNeighborhood;
                    customer.CorrespondenceCity = customerCorrespondenceCity;
                    customer.CorrespondenceState = customerCorrespondenceState;
                    customer.CorrespondenceZipCode = customerCorrespondenceZipCode;
                    customer.CorrespondenceComplement = customerCorrespondenceComplement;
                    customer.ProducerRg = customerProducerRg;
                    customer.Responsible1Name = customerResponsible1Name;
                    customer.Responsible1CPF = customerResponsible1CPF;
                    customer.Responsible1RG = customerResponsible1RG;
                    customer.Responsible1Profession = customerResponsible1Profession;
                    customer.Responsible1MaritalStatus = customerResponsible1MaritalStatus;
                    customer.Responsible1Address = customerResponsible1Address;
                    customer.Responsible1Neighborhood = customerResponsible1Neighborhood;
                    customer.Responsible1City = customerResponsible1City;
                    customer.Responsible1State = customerResponsible1State;
                    customer.Responsible1ZipCode = customerResponsible1ZipCode;
                    customer.Responsible2Name = customerResponsible2Name;
                    customer.Responsible2CPF = customerResponsible2CPF;
                    customer.Responsible2RG = customerResponsible2RG;
                    customer.Responsible2Profession = customerResponsible2Profession;
                    customer.Responsible2MaritalStatus = customerResponsible2MaritalStatus;
                    customer.Responsible2Address = customerResponsible2Address;
                    customer.Responsible2Neighborhood = customerResponsible2Neighborhood;
                    customer.Responsible2City = customerResponsible2City;
                    customer.Responsible2State = customerResponsible2State;
                    customer.Responsible2ZipCode = customerResponsible2ZipCode;
                    customer.Photo = customerPhoto;
                    customer.PaymentCondition = customerPaymentCondition;
                    customer.IEType = customerIEType;
                    customer.FinalConsumer = customerFinalConsumer;
                    customer.BranchCode = customerBranchCode;

                    customerRegisterList.Add(customer);

                }

                reader.Close();
            }

            dbConnection.CloseConnection();
            return customerRegisterList;
        }
    }
}
