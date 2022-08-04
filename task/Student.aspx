<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="ApiTask.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
    <link type="text/css" rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: 'http://localhost/ApiDemo/api/values',
                type: 'get',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
                success: function (data1) {
                    $('#newTable').dataTable({
                        data: data1,
                        columns: [

                            { 'data': 'ID' },
                            { 'data': 'Name' },
                            //{ 'data': 'Email' },
                            { 'data': 'Class'},
                            
                        ]
                    });
                }
            });
            });
    </script> 
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin:5%">
            <div class="jumbotron breadcrumb  d-flex justify-content-center">
                <div class="row text-center ">
                    <div class="col-12">
                        <h1>Student Table</h1>
                    <div>
                        <table id="newTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th> Name</th>
                                    <%--<th>Email</th>--%>
                                    <th>Class</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
