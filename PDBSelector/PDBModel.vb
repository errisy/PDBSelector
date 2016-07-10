Public Class PDBModel
    Inherits DependencyObject
    Public Property ID As String
        Get
            Return GetValue(IDProperty)
        End Get
        Set(ByVal value As String)
            SetValue(IDProperty, value)
        End Set
    End Property
    Public Shared ReadOnly IDProperty As DependencyProperty =
                             DependencyProperty.Register("ID",
                             GetType(String), GetType(PDBModel),
                             New PropertyMetadata(Nothing))
    Public Property Image As ImageSource
        Get
            Return GetValue(ImageProperty)
        End Get
        Set(ByVal value As ImageSource)
            SetValue(ImageProperty, value)
        End Set
    End Property
    Public Shared ReadOnly ImageProperty As DependencyProperty =
                             DependencyProperty.Register("Image",
                             GetType(ImageSource), GetType(PDBModel),
                             New PropertyMetadata(Nothing))
    Public Property Code As String
        Get
            Return GetValue(CodeProperty)
        End Get
        Set(ByVal value As String)
            SetValue(CodeProperty, value)
        End Set
    End Property
    Public Shared ReadOnly CodeProperty As DependencyProperty =
                             DependencyProperty.Register("Code",
                             GetType(String), GetType(PDBModel),
                             New PropertyMetadata(Nothing))

    Public Property CodeFull As String
        Get
            Return GetValue(CodeFullProperty)
        End Get
        Set(ByVal value As String)
            SetValue(CodeFullProperty, value)
        End Set
    End Property
    Public Shared ReadOnly CodeFullProperty As DependencyProperty =
                             DependencyProperty.Register("CodeFull",
                             GetType(String), GetType(PDBModel),
                             New PropertyMetadata(Nothing))

    Public Property Selected As Boolean
        Get
            Return GetValue(SelectedProperty)
        End Get
        Set(ByVal value As Boolean)
            SetValue(SelectedProperty, value)
        End Set
    End Property
    Public Shared ReadOnly SelectedProperty As DependencyProperty =
                             DependencyProperty.Register("Selected",
                             GetType(Boolean), GetType(PDBModel),
                             New PropertyMetadata(False))

    Public Property Models As String
        Get
            Return GetValue(ModelsProperty)
        End Get
        Set(ByVal value As String)
            SetValue(ModelsProperty, value)
        End Set
    End Property
    Public Shared ReadOnly ModelsProperty As DependencyProperty =
                             DependencyProperty.Register("Models",
                             GetType(String), GetType(PDBModel),
                             New PropertyMetadata(Nothing))
End Class
