import { HttpHeaders } from '@angular/common/http';

export const HttpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urlencoded',
        'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
};

// Developer
const deployUrl = 'https://localhost:44381/';

// IIS Deploy
// const deployUrl = 'http://www.defaultidentityapi.code/';
const accountApi = 'api/Account/';
const manageApi = 'api/Manage/';

export const ValidateCookieUrl = deployUrl + manageApi + 'ValidateCookie';
export const TokenUrl = deployUrl + 'Token';
export const LoginUrl = deployUrl + accountApi + 'Login';
export const LogoutUrl = deployUrl + accountApi + 'Logout';
export const RegisterUrl = deployUrl + accountApi + 'Register';
export const ChangePassUrl = deployUrl + manageApi + 'ChangePassword';

export const ValuesUrl = deployUrl + 'api/values';
export const TestUrl = deployUrl + accountApi + 'Test';
