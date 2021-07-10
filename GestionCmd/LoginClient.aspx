<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginClient.aspx.cs" Inherits="GestionCmd.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style>
        body {font-family: Arial, Helvetica, sans-serif;}
    form {
    border: 3px solid #f1f1f1;
    width:650px;
    margin:28vh auto;
    padding:6px;
   

}

input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

button {
        border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #04AA6D;
            color: white;
            padding: 14px 20px;
            cursor: pointer;
            width: 100%;
            margin-left: 0;
            margin-right: 0;
            margin-top: 8px;
        }

button:hover {
  opacity: 0.8;
}

.cancelbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #f44336;
}

.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}

img.avatar {
  width: 40%;
  border-radius: 50%;
}

.container {
  padding: 16px;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
        .nouveauStyle1 {
            color: #F44336;
        }</style>
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <h2 style="text-align:center">Login Client</h2>

        </div>


  <div class="container">
      <label for="uname"><b>Username</b></label>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       &nbsp;<label for="psw"><b>Password</b></label>
      <br />
      <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Button ID="Button1"  runat="server" Height="41px" OnClick="Button1_Click" Text="Se connecter" Width="620px" BackColor="#009900" ForeColor="White" />
      <br />
      <br />
      <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>

  </div>


    </form>

</body>
</html>
