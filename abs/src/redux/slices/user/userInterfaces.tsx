export interface IUser {
  token: string;
  email: string;
  id: string;
  isAdmin: boolean;
}

export interface IUserState {
  user: IUser;
  logged: boolean;
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}
