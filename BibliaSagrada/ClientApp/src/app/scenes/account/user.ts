export interface IUserRegister {
  username: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface IUserLogin {
  email: string;
  password: string;
}

export interface IToken {
  access_token: string;
  expires_in: number;
  token_type: string;
  userName: string;
}

export interface IChangePassword {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}
