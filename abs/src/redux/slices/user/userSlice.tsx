// import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
// import axios from "axios";
// import type { RootState } from "../../store";
// import { IUserState } from "../user/userInterfaces";

// const initialState: IUserState = {
//   user: { token: "", email: "", id: "", isAdmin: false },
//   logged: false,
//   status: "idle",
//   error: null,
// };

// export const loginUser = createAsyncThunk("abs/login", async (obj: { email: string; password: string }) => {
//   const response = await axios.post("https://localhost:44318/api/Account/login", {
//     email: obj.email,
//     password: obj.password,
//   });

//   return {
//     token: response.data.token,
//     code: response.status,
//     email: obj.email,
//     id: response.data.userId,
//     roles: response.data.roles,
//   };
// });

// export const registerUser = createAsyncThunk(
//   "abs/register",
//   async (obj: { email: string; password: string }, { dispatch }) => {
//     const response = await axios.post("https://localhost:44318/api/Account/register", {
//       email: obj.email,
//       password: obj.password,
//       roles: ["User"],
//     });

//     if (response.status === 202) {
//       dispatch(loginUser(obj));
//     }

//     return response.data;
//   }
// );

// export const userSlice = createSlice({
//   name: "user",
//   initialState,
//   reducers: {
//     logout(state) {
//       state.user = { token: "", email: "", id: "", isAdmin: false };
//       state.logged = false;
//     },
//   },
//   extraReducers: (builder) => {
//     builder
//       .addCase(loginUser.pending, (state, action) => {
//         state.status = "loading";
//       })
//       .addCase(loginUser.fulfilled, (state, action) => {
//         state.user.token = action.payload.token;
//         state.user.email = action.payload.email;
//         state.user.id = action.payload.id;

//         if (action.payload.roles.includes("Admin")) {
//           state.user.isAdmin = true;
//         }

//         if (action.payload.code === 202) {
//           state.logged = true;
//         }

//         state.status = "succeeded";
//       })
//       .addCase(loginUser.rejected, (state, action) => {
//         state.status = "failed";
//       });
//   },
// });

// export const { logout } = userSlice.actions;

// export const selectUser = (state: RootState) => state.userReducer.user;
// export const selectLogged = (state: RootState) => state.userReducer.logged;

// export default userSlice.reducer;
export {};
