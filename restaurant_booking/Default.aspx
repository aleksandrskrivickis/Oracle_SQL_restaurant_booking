<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restaurant_booking._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
            </p>
            <p>
                User ID:
                <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True" ValidateRequestMode="Enabled"></asp:TextBox>
            </p>
            <p>
                Number of guests:
                <asp:TextBox ID="TextBox2" runat="server" CausesValidation="True" ValidateRequestMode="Enabled" Width="51px"></asp:TextBox>
            </p>
            <p>
                Date:
            </p>
            <p>
                <asp:Calendar ID="Calendar1" runat="server" SelectedDate="04/01/2018 21:48:10" ValidateRequestMode="Enabled"></asp:Calendar>
            </p>
            <p>
                Time:</p>
            <p>
                <asp:TextBox ID="TextBox3" runat="server" ValidateRequestMode="Enabled" Width="24px"></asp:TextBox>
&nbsp;:
                <asp:TextBox ID="TextBox4" runat="server" ValidateRequestMode="Enabled" Width="24px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ActivityBookingID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="ActivityBookingID" HeaderText="ActivityBookingID" ReadOnly="True" SortExpression="ActivityBookingID" />
                        <asp:BoundField DataField="ActivityID" HeaderText="ActivityID" SortExpression="ActivityID" />
                        <asp:BoundField DataField="BookingID" HeaderText="BookingID" SortExpression="BookingID" />
                        <asp:BoundField DataField="ActivityBookedSlots" HeaderText="ActivityBookedSlots" SortExpression="ActivityBookedSlots" />
                        <asp:BoundField DataField="ActivityBookingFromTime" HeaderText="ActivityBookingFromTime" SortExpression="ActivityBookingFromTime" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ActivityBookingID&quot;, &quot;ActivityID&quot;, &quot;BookingID&quot;, &quot;ActivityBookedSlots&quot;, &quot;ActivityBookingFromTime&quot; FROM &quot;ActivityBookings&quot;"></asp:SqlDataSource>
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
