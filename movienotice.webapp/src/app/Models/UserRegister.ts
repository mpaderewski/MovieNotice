export class UserRegister {
    public Email: string;
    public Password: string;
    public ConfirmPassword: string;
    public UserName: string;
    
    constructor(email: string, password: string, confirmPassword: string, userName: string) {
      this.Email = email;
      this.Password = password;
      this.ConfirmPassword = confirmPassword;
      this.UserName = userName;
     }
    
  }