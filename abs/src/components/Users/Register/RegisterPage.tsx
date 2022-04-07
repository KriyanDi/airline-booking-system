// import React, { useState } from "react";
// import { Button, Form, Grid, Segment } from "semantic-ui-react";
// import { useAppDispatch } from "../../../_redux/hooks";
// import { registerUser } from "../../../redux/slices/user/userSlice";
// import "./RegisterPage.css";
// import PasswordsDontMatch from "./PasswordsDontMatch";
// import { Link } from "react-router-dom";

// const RegisterPage = ({ handleItemClick }: any) => {
//   const dispatch = useAppDispatch();
//   const [email, setEmail] = useState("");
//   const [password1, setPassword1] = useState("");
//   const [password2, setPassword2] = useState("");

//   return (
//     <Grid middle aligned centered className="grid">
//       <Grid.Column>
//         <h2 className="ui image header">
//           <div className="content">Register</div>
//         </h2>

//         <Form>
//           <Segment stacked secondary>
//             <div className="field">
//               <div className="ui left icon input">
//                 <i className="user icon"></i>
//                 <input
//                   type="text"
//                   name="email"
//                   placeholder="E-mail address"
//                   onChange={(e) => {
//                     setEmail(e.target.value);
//                   }}
//                 />
//               </div>
//             </div>

//             <div className="field">
//               <div className="ui left icon input">
//                 <i className="lock icon"></i>
//                 <input
//                   type="password"
//                   name="password1"
//                   placeholder="Password"
//                   onChange={(e) => {
//                     setPassword1(e.target.value);
//                   }}
//                 />
//               </div>
//             </div>

//             <div className="field">
//               <div className="ui left icon input">
//                 <i className="lock icon"></i>
//                 <input
//                   type="password"
//                   name="password2"
//                   placeholder="Password Again"
//                   onChange={(e) => {
//                     setPassword2(e.target.value);
//                   }}
//                 />
//               </div>
//             </div>
//             {password1 !== password2 ? <PasswordsDontMatch /> : null}
//             {/* <Link to="/book"> */}
//             <Button
//               fluid
//               large
//               submit
//               onClick={() => {
//                 dispatch(registerUser({ email: email, password: password1 }));
//               }}
//             >
//               Register
//             </Button>
//             {/* </Link> */}
//           </Segment>

//           <div className="ui error message"></div>
//         </Form>

//         <div className="ui message">
//           Already registered?{" "}
//           <Link to="/login">
//             <a href="" onClick={() => handleItemClick("login")}>
//               Login
//             </a>
//           </Link>
//         </div>
//       </Grid.Column>
//     </Grid>
//   );
// };

// export default RegisterPage;
export {};
