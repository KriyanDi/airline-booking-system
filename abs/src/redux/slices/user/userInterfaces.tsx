export interface IUser {
  token: string;
}

export interface IUserState {
  user: IUser;
  logged: boolean;
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}
