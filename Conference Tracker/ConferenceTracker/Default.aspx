<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConferenceTracker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <script type="text/javascript">
      function Clear() {

          var mytextbox = document.getElementById('userInput');
          if (mytextbox.value != "") {
              mytextbox.value = "";
          }
          else {
              alert("Nothing to Clear");
          }
      }

      /*----------------------Common Method--------------------------------------*/

      function Reset() {
          var mytextboxinput = document.getElementById('sResultTextBox');
          var mytextboxoutput = document.getElementById('userInput');
          mytextboxinput.value = "";
          mytextboxoutput.value = "";

      }
  </script>
    <link href="CSS/ColorDefault.css" rel="stylesheet" />
    <div class="jumbotron">
        <h1>Conference Track Manager Interface</h1>
        <p class="lead"></p>
      <%--  <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-12">
           <table style="width:100%">
        <tr>
            <td style="width:5%"></td>
            <td style="width:50%">
                <asp:TextBox id="userInput" runat="server" TextMode="MultiLine" Columns="5" Rows="5" ClientIDMode="Static"></asp:TextBox> 
            </td>
            <td></td>
            <td >
                <%--<button id="btnValidate" class="button" onclick="ValidateTextInput()">Validate</button>--%>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>

        <tr>
            <td></td>
        </tr>
        <tr>
            <td style="width:5%"></td>
            <td colspan="2">
                <%--<button id="btnClear" class="button" onclick="Clear()">Clear</button>--%>
                <asp:Button ID ="btnClear" CssClass ="button" OnClientClick="Clear();  return false;" Text ="Clear" runat="server" ClientIDMode="Static"/>
                <asp:Button id="btnRunManager" CssClass="button" runat="server" Text="Create Tracker" OnClick="btnRunManager_Click" />
            </td>
            <td>
            </td>
            <td></td>

        </tr>
        <tr>
            <td style="width:5%"></td>
            <td>
                <h3>Output</h3>
            </td>
            <td>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td style="width:5%"></td>
            
            <td colspan="2">
                <p id="paragraph">
                   This area will contain result of the Tracker Manager Process
                </p>
            </td>
            <td></td>
            <td></td>
        </tr>
                 <tr>
            <td style="width:5%"></td>
            <td style="width:50%">
                <asp:TextBox id="sResultTextBox" runat="server" TextMode="MultiLine" Columns="5" Rows="20" ClientIDMode="Static"></asp:TextBox> 
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width:5%"></td>
            <td>
                 <asp:Button ID ="btnReset" CssClass ="button" OnClientClick="Reset();  return false;" Text ="Click to Reset" runat="server" ClientIDMode="Static"/>
               
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
        </div>
    </div>

</asp:Content>
