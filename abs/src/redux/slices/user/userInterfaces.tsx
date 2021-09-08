export interface IUser {
  token: string;
}

export interface IUserState {
  user: IUser;
  status: "idle" | "loading" | "succeeded" | "failed";
  error: string | null;
}
