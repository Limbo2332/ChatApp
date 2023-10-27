export interface IResetPassword {
  email: string;
  emailToken: string;
  newPassword: string;
  confirmPassword: string;
}
