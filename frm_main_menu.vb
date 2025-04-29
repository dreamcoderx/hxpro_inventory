Imports System.Collections.Specialized
Imports DevExpress.XtraTabbedMdi
Public Class frm_main_menu


    Private Sub frm_main_menu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim mdiManager As XtraTabbedMdiManager = New XtraTabbedMdiManager()
        mdiManager.MdiParent = Me
        Dim a As New LoginAdmin
        If a.ShowDialog <> DialogResult.OK Then
            Me.Dispose()
        End If
    End Sub
    Dim f_frmReportQty As frmReportQty
    Dim f_frmInventoryList As frmInventoryList
    Dim f_frmDeliveryView As frmDeliveryView
    Dim f_frmReturnSlipview As frmReturnSlipview
    Dim f_frmRepairView As frmRepairView
    Dim f_frmRepairViewAll As New frmRepairViewAll


    Private Sub BRANDMAKEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRANDMAKEToolStripMenuItem.Click
        load_frm_brand()
    End Sub

    Private Sub PARTNUMBERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTNUMBERToolStripMenuItem.Click
        load_frm_part()
    End Sub

    Private Sub SUBCATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBCATEGORYToolStripMenuItem.Click
        load_frm_sub_category()
    End Sub

    Private Sub CATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYToolStripMenuItem.Click
        load_frm_category()
    End Sub

    Private Sub CREToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREToolStripMenuItem.Click
        load_frm_create()
    End Sub

    Private Sub VIEWToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWToolStripMenuItem1.Click
        load_frm_item_list()
    End Sub

    Private Sub USERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERToolStripMenuItem.Click
        load_frm_user()
    End Sub

    Sub load_frm_brand()
        Dim booleanNew As Boolean = False
        If f_brand Is Nothing Then
            booleanNew = True
        ElseIf f_brand.IsDisposed Then
            booleanNew = True
        End If

        If booleanNew Then
            f_brand = New frm_brand1
        End If
        f_brand.MdiParent = Me
        f_brand.Show()
        f_brand.Activate()
    End Sub

    Sub load_frm_part()
        Dim booleanNew As Boolean = False
        If f_part Is Nothing Then
            booleanNew = True
        ElseIf f_part.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_part = New frm_part1
        End If
        f_part.MdiParent = Me
        f_part.Show()
        f_part.Activate()
    End Sub

    Sub load_frm_category()
        Dim booleanNew As Boolean = False
        If f_category Is Nothing Then
            booleanNew = True
        ElseIf f_category.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_category = New frm_category
        End If
        f_category.MdiParent = Me
        f_category.Show()
        f_category.Activate()
    End Sub

    Sub load_frm_sub_category()
        Dim booleanNew As Boolean = False
        If f_sub_category Is Nothing Then
            booleanNew = True
        ElseIf f_sub_category.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_sub_category = New frm_sub_category
        End If
        f_sub_category.MdiParent = Me
        f_sub_category.Show()
        f_sub_category.Activate()
    End Sub

    Sub load_frm_user()
        Dim booleanNew As Boolean = False
        If f_user Is Nothing Then
            booleanNew = True
        ElseIf f_user.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_user = New frmUser
        End If
        f_user.MdiParent = Me
        f_user.Show()
        f_user.Activate()
    End Sub

    Sub loadCreateRental(ByVal strRentalNo As String)
        Dim booleanNew As Boolean = False
        If f_CreateRental Is Nothing Then
            booleanNew = True
        ElseIf f_CreateRental.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CreateRental = New frmCreateRentalfin
        End If
        f_CreateRental.MdiParent = Me
        f_CreateRental.txtRentalNO.Text = strRentalNo
        f_CreateRental.Show()
        f_CreateRental.Activate()
    End Sub

    Sub loadCheckOutRental(ByVal strRentalID As String, ByVal strRentalNo As String)
        f_CheckOutRental = New frmRentalCheckOutFin
        f_CheckOutRental.MdiParent = Me
        f_CheckOutRental.Text = "CHECK OUT:" & strRentalNo
        f_CheckOutRental.lblRentalID.Text = strRentalID
        f_CheckOutRental.Show()
        f_CheckOutRental.Activate()
    End Sub

    Sub loadCheckINRental()
        Dim booleanNew As Boolean = False
        If f_CheckInRental Is Nothing Then
            booleanNew = True
        ElseIf f_CheckInRental.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CheckInRental = New frmRenCheckIn1
        End If
        f_CheckInRental.MdiParent = Me
        f_CheckInRental.Show()
        f_CheckInRental.Activate()
    End Sub

    Sub load_frm_item_list()
        Dim booleanNew As Boolean = False
        If f_view Is Nothing Then
            booleanNew = True
        ElseIf f_view.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_view = New frm_item_list
        End If
        f_view.MdiParent = Me
        f_view.Show()
        f_view.Activate()
    End Sub

    Sub load_frm_create()
        Dim booleanNew As Boolean = False
        If f_create Is Nothing Then
            booleanNew = True
        ElseIf f_create.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_create = New frm_create_asset_1
        End If
        f_create.MdiParent = Me
        f_create.Show()
        f_create.Activate()
    End Sub

    Sub loadfrmRentalView()
        Dim booleanNew As Boolean = False
        If f_CheckOutView Is Nothing Then
            booleanNew = True
        ElseIf f_CheckOutView.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CheckOutView = New frmRentalCheckOutVw1
        End If
        f_CheckOutView.MdiParent = Me
        f_CheckOutView.Show()
        f_CheckOutView.Activate()
    End Sub

    Sub loadfrmCreateSetItem(ByVal strSetBarcode)
        Dim booleanNew As Boolean = False
        If f_CreateSet Is Nothing Then
            booleanNew = True
        ElseIf f_CreateSet.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CreateSet = New frmSetAddRemove1
        End If
        f_CreateSet.txtSetBarcode.Text = strSetBarcode
        f_CreateSet.MdiParent = Me
        f_CreateSet.Show()
        f_CreateSet.Activate()
    End Sub

    Private Sub CREATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATEToolStripMenuItem.Click
        Dim a As New frmCreateRentalHDR1
        Dim booleanNew As Boolean = False
        If f_CreateRental Is Nothing Then
            booleanNew = True
        ElseIf f_CreateRental.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            If a.ShowDialog() = DialogResult.OK Then
                loadCreateRental(a.txtRentalNO.Text)
                a.Dispose()
            End If
        Else
            MsgBox("A create Rental is currently open, please close this to create a new rental!")
        End If

    End Sub

    Private Sub VIEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWToolStripMenuItem.Click
        Dim a As New frmRentalCheckOutVw1
        Dim booleanNew As Boolean = False
        If f_CheckOutRental Is Nothing Then
            booleanNew = True
        ElseIf f_CheckOutRental.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            If a.ShowDialog() = DialogResult.OK Then
                loadCreateRental(a.lblRentalNo.Text)
                a.Dispose()
            End If
        Else
            MsgBox("A Checkout Rental is currently open, please close it first!")
        End If
    End Sub

    Private Sub CREATEToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATEToolStripMenuItem1.Click
        Dim a As New frmCreateRepairHeader
        a.Show()
    End Sub

    Private Sub VIEWToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWToolStripMenuItem2.Click
        If f_frmRepairView Is Nothing OrElse f_frmRepairView.IsDisposed Then
            f_frmRepairView = New frmRepairView
        End If
        f_frmRepairView.MdiParent = Me
        f_frmRepairView.Show()
        f_frmRepairView.Activate()
    End Sub

    Private Sub CREATEToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATEToolStripMenuItem2.Click
        Dim a As New frmReturnSlip
        a.Show()
    End Sub

    Private Sub VIEWToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWToolStripMenuItem3.Click
        If f_frmReturnSlipview Is Nothing OrElse f_frmReportQty.IsDisposed Then
            f_frmReturnSlipview = New frmReturnSlipview
        End If
        f_frmReturnSlipview.MdiParent = Me
        f_frmReturnSlipview.Show()
        f_frmReturnSlipview.Activate()
    End Sub

    Private Sub CREATEToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATEToolStripMenuItem3.Click
        Dim A As New frmDelivery
        A.Show()
    End Sub

    Private Sub VIEWToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWToolStripMenuItem4.Click
        If f_frmDeliveryView Is Nothing OrElse f_frmDeliveryView.IsDisposed Then
            f_frmDeliveryView = New frmDeliveryView
        End If
        f_frmDeliveryView.MdiParent = Me
        f_frmDeliveryView.Show()
        f_frmDeliveryView.Activate()
    End Sub

    Private Sub CREATESCANToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATESCANToolStripMenuItem1.Click
        Dim a As New frmCreateAssetScan
        a.Show()
    End Sub

    Private Sub loadfrmCrewList()
        Dim booleanNew As Boolean = False
        If f_CrewList Is Nothing Then
            booleanNew = True
        ElseIf f_CrewList.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CrewList = New frmCrewList
        End If
        f_CrewList.MdiParent = Me
        f_CrewList.Show()
        f_CrewList.Activate()
    End Sub

    Private Sub CREWLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREWLISTToolStripMenuItem.Click
        loadfrmCrewList()
    End Sub

    Private Sub RETURNToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURNToolStripMenuItem1.Click
        Dim A As New frmRepairReturn
        A.Show()
    End Sub

    Private Sub SCANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCANToolStripMenuItem.Click
        Dim a As New frmInventoryScan
        a.Show()
    End Sub

    Private Sub VIEW2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEW2ToolStripMenuItem.Click
        If f_frmInventoryList Is Nothing OrElse f_frmInventoryList.IsDisposed Then
            f_frmInventoryList = New frmInventoryList
        End If
        f_frmInventoryList.MdiParent = Me
        f_frmInventoryList.Show()
        f_frmInventoryList.Activate()
    End Sub

    Private Sub VIEWFORRETURNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWFORRETURNToolStripMenuItem.Click
        If f_frmRepairViewAll Is Nothing OrElse f_frmRepairViewAll.IsDisposed Then
            f_frmRepairViewAll = New frmRepairViewAll
        End If
        f_frmRepairViewAll.MdiParent = Me
        f_frmRepairViewAll.Show()
        f_frmRepairViewAll.Activate()
    End Sub

    Private Sub loadfrmGroupBarcode()
        Dim booleanNew As Boolean = False
        If f_GroupBarcode Is Nothing Then
            booleanNew = True
        ElseIf f_GroupBarcode.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_GroupBarcode = New frmGroupBarcodeView
        End If
        f_GroupBarcode.MdiParent = Me
        f_GroupBarcode.Show()
        f_GroupBarcode.Activate()
    End Sub

    Private Sub SETITEMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETITEMToolStripMenuItem.Click
        Dim a As New frmSetBarcodeView1
        If a.ShowDialog() = DialogResult.OK Then
            loadfrmCreateSetItem(a.lblSetBarcode.Text)
            a.Dispose()
        End If
    End Sub

    Private Sub GROUPITEMToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPITEMToolStripMenuItem1.Click
        loadfrmGroupBarcode()
    End Sub

    Private Sub RENTALCHECKOUTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RENTALCHECKOUTToolStripMenuItem1.Click
        Dim a As New frmRentalCheckOutHdr
        Dim dResult As New DialogResult
        dResult = a.ShowDialog()
        If dResult = DialogResult.OK Then
            loadCheckOutRental(a.lblRentalID.Text, a.lblRentalNumber.Text)
            a.Dispose()
            Exit Sub
        End If
    End Sub

    Private Sub RENTALCHECKINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RENTALCHECKINToolStripMenuItem.Click
        loadCheckINRental()
    End Sub

    Private Sub AVAILABLEQTYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AVAILABLEQTYToolStripMenuItem.Click
        If f_frmReportQty Is Nothing OrElse f_frmReportQty.IsDisposed Then
            f_frmReportQty = New frmReportQty
        End If
        f_frmReportQty.MdiParent = Me
        f_frmReportQty.Show()
        f_frmReportQty.Activate()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub COMPORTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles COMPORTToolStripMenuItem.Click
        Dim f As New frmSettingsCom
        f.Show()
    End Sub

    
End Class