Imports DevExpress.XtraBars
Imports DevExpress.XtraTabbedMdi
'Imports Infragistics.Win.UltraWinTree
Public Class frm_main_rental_in_out

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mdiManager As XtraTabbedMdiManager = New XtraTabbedMdiManager()
        mdiManager.MdiParent = Me

        Dim a As New LoginForm1

        If a.ShowDialog = DialogResult.OK Then

        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub BRANDMAKEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_brand
        'a.Show()
        load_frm_brand()

    End Sub

    Private Sub PARTNUMBERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_part
        'a.Show()
        load_frm_part()
    End Sub

    Private Sub SUBCATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_sub_category
        'a.Show()
        load_frm_sub_category()
    End Sub

    Private Sub CATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_category
        'a.Show()
        load_frm_category()
    End Sub

    Private Sub CREToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_create_
        'a.Show()
        load_frm_create()
    End Sub

    Private Sub VIEWToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_item_list
        'a.Show()
        load_frm_item_list()
    End Sub

    Private Sub USERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New frm_user
        'a.Show()
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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

    Sub loadCheckOutRental(ByVal strRentalID As String)
        Dim booleanNew As Boolean = False
        If f_CheckOutRental Is Nothing Then
            booleanNew = True
        ElseIf f_CheckOutRental.IsDisposed Then
            booleanNew = True
        End If
        If booleanNew Then
            f_CheckOutRental = New frmRentalCheckOutFin
        End If
        f_CheckOutRental.MdiParent = Me
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
        ' f_CheckInRental.lblRentalID.Text = strRentalID
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
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
            'If Not frm2.Init() Then
            'frm2 = Nothing
            'Exit Sub
            'End If
        End If
        f_CreateSet.txtSetBarcode.Text = strSetBarcode
        f_CreateSet.MdiParent = Me
        f_CreateSet.Show()
        f_CreateSet.Activate()
    End Sub

    Private Sub UPLOADToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frm_upload
        a.Show()
    End Sub


    Private Sub RENTALCHECKOUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RENTALCHECKOUTToolStripMenuItem.Click
        Dim a As New frmRentalCheckOutHdr
        Dim dResult As New DialogResult

        dResult = a.ShowDialog()
        If dResult = DialogResult.OK Then
            loadCheckOutRental(a.lblRentalID.Text)
            a.Dispose()
            Exit Sub
        End If

        'If dResult = Windows.Forms.DialogResult.Yes Then
        '    loadCheckINRental(a.lblRentalID.Text)
        '    a.Dispose()
        '    Exit Sub
        'End If

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
        'loadfrmRentalView()
        Dim a As New frmRentalCheckOutVw1

        Dim booleanNew As Boolean = False
        If f_CheckOutRental Is Nothing Then
            booleanNew = True
        ElseIf f_CheckOutRental.IsDisposed Then
            booleanNew = True
        End If

        If booleanNew Then
            If a.ShowDialog() = DialogResult.OK Then
                'loadCheckOutRental(a.lblRentalID.Text)
                loadCreateRental(a.lblRentalNo.Text)

                'loadCreateRental(a.txtRentalNO.Text)
                a.Dispose()
            End If
        Else
            MsgBox("A Checkout Rental is currently open, please close it first!")
        End If
    End Sub

    Private Sub CREATEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'loadfrmCreateSetItem()

    End Sub

    Private Sub VIEWEDITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New frmSetBarcodeView1
        If a.ShowDialog() = DialogResult.OK Then
            loadfrmCreateSetItem(a.lblSetBarcode.Text)
            a.Dispose()
        End If
    End Sub

    Private Sub CHECKINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKINToolStripMenuItem.Click
        'Dim a As New frmRenCheckIn
        'a.Show()
        loadCheckINRental()
    End Sub
End Class
