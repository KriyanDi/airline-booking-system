import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { useAppDispatch } from "../../hooks";
import type { RootState } from "../../store";
import { IUser, IUserState } from "../user/userInterfaces";

const initialState: IUserState = {
  user: { token: "" },
  logged: false,
  status: "idle",
  error: null,
};

export const loginUser = createAsyncThunk("abs/login", async (obj: { email: string; password: string }) => {
  const response = await axios.post("https://localhost:44318/api/Account/login", {
    email: obj.email,
    password: obj.password,
  });

  return response.data;
});

export const registerUser = createAsyncThunk("abs/register", async (obj: { email: string; password: string }) => {
  const dispatch = useAppDispatch();

  const response = await axios.post("https://localhost:44318/api/Account/register", {
    email: obj.email,
    password: obj.password,
    roles: ["User"],
  });

  if (response.status === 202) {
    dispatch(loginUser(obj));
  }

  console.log(response);

  return response.data;
});

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    logout(state) {
      state.user = { token: "" };
      state.logged = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loginUser.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.user.token = action.payload.token;
        state.logged = true;
        state.status = "succeeded";
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.status = "failed";
      });
  },
});

export const { logout } = userSlice.actions;

export const selectUser = (state: RootState) => state.userReducer.user;
export const selectLogged = (state: RootState) => state.userReducer.logged;

export default userSlice.reducer;
