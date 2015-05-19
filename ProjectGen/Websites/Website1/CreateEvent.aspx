<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="CreateEvent.aspx.cs" Inherits="CreateEvents" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <h2 style="margin-left:30%">
Create an event
</h2>

<div>
<p style="height: 55px">&nbsp; Name&nbsp; <asp:TextBox ID="TBname" Height="30%" Width="50%" BorderColor="Black" runat="server" CssClass="css-input"></asp:TextBox>
</div>
<div>
&nbsp; State &nbsp; 
    <asp:DropDownList ID="estado" runat="server" Height="16px" Width="117px">
        <asp:ListItem>Public</asp:ListItem>
        <asp:ListItem>Private</asp:ListItem>
    </asp:DropDownList>
&nbsp;<p style="float:right; margin-right:30%">

</p>
<p style="float:right;"></p>

<p>
Description
</p>

</div>
<div style=" float:left; height:15%; width:50%";>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Height="100%" 
        Width="100%" TextMode="MultiLine" CssClass="css-input"></asp:TextBox>
</div>

<div style=" float:right;";>
<table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="LabelUserHobbies" runat="server" Text="User hobbies:"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            <asp:Label ID="LabelEventHobbies" runat="server" Text="Event hobbies:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="ListUserHobbies" runat="server" Width="150px" >
                            </asp:ListBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonToRight" runat="server" Text=">>" OnClick="ButtonToRight_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
                            <asp:Button ID="ButtonToLeft" runat="server" Text="<<" OnClick="ButtonToLeft_Click" />
                        </td>
                        <td>
                            <asp:ListBox ID="ListEventHobbies" runat="server"  Width="150">
                            </asp:ListBox>
                        </td>
                    </tr>
                </table>
</div>

<div>
<div style="margin-top: 13%; margin-left: 20%;" >
    <asp:Table ID="Table1" runat="server" Height="42px" Width="400px" style="margin-left: 0px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Inicio" runat="server" Text="Start DateTime"  Visible="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label style="margin-left: 15%" ID="Fin" runat="server" Text="End DateTime" Visible="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="iniciotext" runat="server" Width="80px">&nbsp;</asp:TextBox> &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
    </asp:DropDownList> h
                <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
        <asp:ListItem>24</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>26</asp:ListItem>
        <asp:ListItem>27</asp:ListItem>
        <asp:ListItem>28</asp:ListItem>
        <asp:ListItem>29</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>31</asp:ListItem>
        <asp:ListItem>32</asp:ListItem>
        <asp:ListItem>33</asp:ListItem>
        <asp:ListItem>34</asp:ListItem>
        <asp:ListItem>35</asp:ListItem>
        <asp:ListItem>36</asp:ListItem>
        <asp:ListItem>37</asp:ListItem>
        <asp:ListItem>38</asp:ListItem>
        <asp:ListItem>39</asp:ListItem>
        <asp:ListItem>40</asp:ListItem>
        <asp:ListItem>41</asp:ListItem>
        <asp:ListItem>42</asp:ListItem>
        <asp:ListItem>43</asp:ListItem>
        <asp:ListItem>44</asp:ListItem>
        <asp:ListItem>45</asp:ListItem>
        <asp:ListItem>46</asp:ListItem>
        <asp:ListItem>47</asp:ListItem>
        <asp:ListItem>48</asp:ListItem>
        <asp:ListItem>49</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>51</asp:ListItem>
        <asp:ListItem>52</asp:ListItem>
        <asp:ListItem>53</asp:ListItem>
        <asp:ListItem>54</asp:ListItem>
        <asp:ListItem>55</asp:ListItem>
        <asp:ListItem>56</asp:ListItem>
        <asp:ListItem>57</asp:ListItem>
        <asp:ListItem>58</asp:ListItem>
        <asp:ListItem>59</asp:ListItem>
    </asp:DropDownList> m
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="fintext" runat="server" Width="80px"> &nbsp; </asp:TextBox> &nbsp;
                <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
    </asp:DropDownList> h
                <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
        <asp:ListItem>24</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>26</asp:ListItem>
        <asp:ListItem>27</asp:ListItem>
        <asp:ListItem>28</asp:ListItem>
        <asp:ListItem>29</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>31</asp:ListItem>
        <asp:ListItem>32</asp:ListItem>
        <asp:ListItem>33</asp:ListItem>
        <asp:ListItem>34</asp:ListItem>
        <asp:ListItem>35</asp:ListItem>
        <asp:ListItem>36</asp:ListItem>
        <asp:ListItem>37</asp:ListItem>
        <asp:ListItem>38</asp:ListItem>
        <asp:ListItem>39</asp:ListItem>
        <asp:ListItem>40</asp:ListItem>
        <asp:ListItem>41</asp:ListItem>
        <asp:ListItem>42</asp:ListItem>
        <asp:ListItem>43</asp:ListItem>
        <asp:ListItem>44</asp:ListItem>
        <asp:ListItem>45</asp:ListItem>
        <asp:ListItem>46</asp:ListItem>
        <asp:ListItem>47</asp:ListItem>
        <asp:ListItem>48</asp:ListItem>
        <asp:ListItem>49</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>51</asp:ListItem>
        <asp:ListItem>52</asp:ListItem>
        <asp:ListItem>53</asp:ListItem>
        <asp:ListItem>54</asp:ListItem>
        <asp:ListItem>55</asp:ListItem>
        <asp:ListItem>56</asp:ListItem>
        <asp:ListItem>57</asp:ListItem>
        <asp:ListItem>58</asp:ListItem>
        <asp:ListItem>59</asp:ListItem>
    </asp:DropDownList> m
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </asp:TableHeaderCell>
            <asp:TableCell>
                <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged"  ShowGridLines="True" Width="220px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
&nbsp;</div>
    <p>
        Place &nbsp;
<asp:TextBox ID="Lugar" Height="30%" Width="50%" BorderColor="Black" runat="server" CssClass="css-input"></asp:TextBox>
<asp:Table runat="server" ID="tableInvitation" border="0" cellpadding="0" cellspacing="0">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="LabelUsers" runat="server" Text="Users:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell> 
                            <asp:Label ID="aux" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelGroupUsers" runat="server" Text="Group users:"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ListBox ID="ListBoxUsers" runat="server" Width="150px" >
                            </asp:ListBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" Text=">>" OnClick="ButtonToRightUsers_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
                            <asp:Button ID="Button2" runat="server" Text="<<" OnClick="ButtonToLeftUsers_Click" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ListBox ID="ListBoxGroupUsers" runat="server"  Width="150">
                            </asp:ListBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
</p>
<p style="float: right; margin-right: 20%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Create Event" OnClick="Button_Create" CssClass="btn"
                          />
</p>

</div>


</asp:Content>

