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

export interface IChangePassword {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}

export interface IChangeNumberVercicles {
  numberVercicles: number;
}
