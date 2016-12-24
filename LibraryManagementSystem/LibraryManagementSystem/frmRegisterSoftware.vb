Imports Machine
Imports Machine.MachineInfo
Public Class frmRegisterSoftware
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Trail = My.Settings.Trail - 1
        My.Settings.Save()
        Label2.Text = My.Settings.Trail
        If My.Settings.Trail >= 0 Then
            frmSplash.Show()
            Me.Close()
        End If
        If My.Settings.Trail < 0 Then
            MsgBox("You Trail Software is Expired, Please Purcharse Product Key", MsgBoxStyle.Information)
            Dim enterKey = InputBox("Please Enter Product Key")
            If enterKey = Trim(generateUniqueKey()) Then
                My.Settings.TrailE = "Yes"
                My.Settings.Save()
                frmSplash.Show()
                Me.Close()
            Else
                Me.Close()

            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim enterKey = InputBox("Please Enter Product Key")
        If enterKey = Trim(generateUniqueKey()) Then
            My.Settings.TrailE = "Yes"
            My.Settings.Save()
            frmSplash.Show()
            Me.Close()
        Else
            MsgBox("Invalid Product Key", MsgBoxStyle.Critical, "LMS")

        End If
    End Sub

    Private Sub frmRegisterSoftware_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Label2.Text = My.Settings.Trail
        If My.Settings.TrailE = "Yes" Then
            frmSplash.Show()
            Me.Close()
        End If
    End Sub
    Function generateUniqueKey()
        Dim SerialKey As String = ""
        Dim MyMachine As MachineInfo = New MachineInfo
        'Creating machine Object
        Dim Myprcessors() As ProcessorIfo
        'Fill Processors Information Object
        Myprcessors = MyMachine.Processors
        'Assighning the first Processor to its TextBox
        SerialKey = Mid(Myprcessors(0).ProcessorId, 1, 5) + "-"

        Dim MyHardDisks() As HardDiskIfo
        'Fill HardDisk Information Object
        MyHardDisks = MyMachine.HardDisks
        'Assighning the first Hard Disk Model to its TextBox
        SerialKey = SerialKey + Mid(MyHardDisks(0).model, 1, 5) + "-"
        'Dimension Components  information for Computer Id .  Contains eight components
        Dim MyId As MachineidComponentsInfo
        'Fill Machine id component information object
        MyId = MyMachine.MachineIdComponents
        'Assigning  the eight Machine id component  to corresponding TextBox
        SerialKey = SerialKey + MyId.Component2 + "-"
        SerialKey = SerialKey + MyId.Component1 + "-"
        Dim MyActivation As MachineActivationComponentsInfo
        'Fill Activation code component information object. it takes four strings parameters To Have Variety for activation Code For Different versions
        MyActivation = MyMachine.MachineActivationComponents("Arun", "Sotware", "LIBRARY MANAGEMENT", "SOFTWARE")
        'Assigning  the eight Activation Code component  to corresponding TextBox
        SerialKey = SerialKey + MyActivation.Component1 + "-"
        SerialKey = SerialKey + MyActivation.Component2
        Return (SerialKey)
    End Function
End Class