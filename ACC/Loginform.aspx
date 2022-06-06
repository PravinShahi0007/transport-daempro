<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginform.aspx.cs" Inherits="ACC.Loginform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous" />
    <style>
        .back{
            background-image: url('images/bg.png');
            background-size:cover;
            min-height: 500px;
        }
        .sub{
            border-radius: 25px;
            padding: 10px  100px 10px 100px;
            background:linear-gradient(162deg, rgba(0,0,255,.8), rgb(158 29 224 / 70%));
            font-size: 25px;
        }
        .sig{
            border-radius: 25px;
            padding: 10px  100px 10px 100px;
            font-size: 25px;
            float:right;
            background-color: aliceblue;
            color: black;
        }
        .inp{
            border: none;
            border-bottom: 2px solid black;
            font-size: 25px;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-fQybjgWLrvvRgtW6bFlB7jaZrFsaBXjsOMm/tB9LTS58ONXgqbR9W8oWht/amnpF" crossorigin="anonymous"></script>
</head>
<body>
    <div class="container-fluid">
        <div class="row" style="min-height: 680px;">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-1"></div>
                    <div class="col-sm-10">
                        <br /><br />
                     
                        
                        <div class="logo">
                            
                            <img src="images/Transport%20logo.png" height="200"/>
                        </div>
                        <br />
                        <form id="form1" runat="server">
                            <label style="font-size:20px; font-weight: bold; color: #beb9b9;">E-mail</label><br /><br />
                            <input type="email" class="form-control inp"  required/><br />
                             <label style="font-size:20px; font-weight: bold; color: #beb9b9;">Password</label><br /><br />
                            <input id="Text" type="password" class="form-control inp" required/><br />
                            <button class="btn btn-primary sub">Login</button> <button class="btn btn-primary sig">Signup</button>
                        </form>
                    </div>
                    <div class="col-sm-1"></div>
                </div>
            </div>
            <div class="col-sm-6 back">
                
            </div>
        </div>
        <div class="row" style="min-height: 40px; background:linear-gradient(162deg, rgba(0,0,255,.8), rgb(158 29 224 / 70%));">
        </div>
    </div>
</body>
</html>
