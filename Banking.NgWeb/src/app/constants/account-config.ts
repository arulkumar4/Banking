export const AccountConfig = {
  getOneCustomerDetails: 'api/Customer/GetCustomerDetails?customerId=&accountNo=',
  postNewCustomer: 'api/Customer/AddNewCustomer',
  putCustomerDetails: 'api/Customer/UpdateCustomerDetails?customerId=',
  getAllCustomerAccount: 'api/Account/GetAllCustomerAccounts',
  getOneCustomerAccount_cusId: 'api/Account/GetCustomerAccounts?customerId=',
  getOneCustomerAccount_accNo: '&accountNo=',
  getAccountByAccountType: 'api/Account/GetAccountByAcountType',
  getAccountByBalance: 'api/AccountGetAccountByBalance',
  getAccountByStatus: 'api/Account/GetCustomerByAccountStatus',
  putAccountPassword: 'api/Account/UpdateAccountPassword',
  deleteAccount: 'api/Account/DeleteAccount'
}
