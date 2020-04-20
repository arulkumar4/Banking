export const AccountConfig = {
  getOneCustomerDetails_id: 'api/Customer/GetCustomerDetails?customerId=',
  getOneCustomerDetails_accNo: '&accountNo=',
  getAllCustomerAccount: 'api/Account/GetAllCustomerAccounts',
  getOneCustomerAccount_cusId: 'api/Account/GetCustomerAccounts?customerId=',
  getOneCustomerAccount_accNo: '&accountNo=',
  getAllAccountType: 'api/AccountTypeController/GetAllAccountType',
  getOneAccountType: 'api/AccountTypeController/GetOneAccountType?acctypeId=',
  postNewCustomer: 'api/Customer/AddNewCustomer?empId=',
  postAccountType: 'api/AccountTypeController/AddNewAccountType',
  putCustomerDetails: 'api/Customer/UpdateCustomerDetails?customerId=',
  putAccountPassword: 'api/Account/UpdateAccountPassword',
  putAccountType: 'api/AccountTypeController/UpdateAccountType',
  deleteAccount_no: 'api/Account/DeleteAccount?number=',
  deleteAccount_pass: '&pass=',
  deleteAccountType: 'api/AccountTypeController/DeleteAccountType?acctype='
}
