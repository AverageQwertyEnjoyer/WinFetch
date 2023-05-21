Imports Pastel
Imports System.Drawing
Imports System.Threading

Module Module1

    Sub Main()

        Dim intros As String() = Environment.GetCommandLineArgs()
        Dim intro As Byte = 1

        If Not UBound(intros) = 0 Then

            Try

                intro = Int32.Parse(intros(1))

                If intro < 0 Or intro > 4 Then

                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.Write("ERROR: incorrect arguments")
                    Console.ResetColor()

                    GoTo fail

                End If

            Catch ex As Exception

                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.Write("ERROR: incorrect arguments ")
                Console.ResetColor()

                GoTo fail

            End Try

        End If


        Console.Title = "WINFETCH"
        Console.CursorVisible = False

        Dim T As String = String.Empty
        Dim Sw1 As Boolean = True
        Dim R(38, 10), G(38, 10), B(38, 10) As Byte
        Dim c1() As Byte = {230, 115, 115}
        Dim c2() As Byte = {100, 190, 230}

        Dim C As Int16
        Dim StrLogo() As String = {"████████████", " ████████████         ", " ████████████", " ████████████        ", "  ████████████", " ████████████       ",
                                "   ████████████", " ████████████      ", "    ████████████", " ████████████     ", "     ▄▄▄▄▄▄▄▄▄▄▄▄", " ▄▄▄▄▄▄▄▄▄▄▄▄    ",
                                "     ▀███████████▄", "▀███████████▄   ", "      ▀███████████▄", "▀███████████▄  ", "       ▀███████████▄", "▀███████████▄ ",
                                "        ▀███████████▄", "▀███████████▄", "         ▀▀▀▀▀▀▀▀▀▀▀▀ ", "▀▀▀▀▀▀▀▀▀▀▀▀"}
        Dim ChrLogo(,) As String =
        {
        {"   ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "", vbCrLf},
        {"    ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "", vbCrLf},
        {"     ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "", vbCrLf},
        {"      ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "", vbCrLf},
        {"       ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "", vbCrLf},
        {"        ", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", " ", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "", vbCrLf},
        {"        ", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", vbCrLf},
        {"         ", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", vbCrLf},
        {"          ", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", vbCrLf},
        {"           ", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", "▀", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "▄", vbCrLf},
        {"            ", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", " ", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", " ", vbCrLf}
        }



        Dim ByteLogo() As Byte = {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7,'
                                  0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7,'
                                  0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 7,'
                                  0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 7, '  'Tis now a block
                                  0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 7,'
                                  0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 7,
                                  0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 7,
                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 7,
                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 7,
                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 7,
                                  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 7}

        Console.Write(vbCrLf & colour("──■ Created by AverageQwertyEnjoyer" & vbCrLf & "  ╚═══╕ ", c1) & colour("WINFETCH v0.2.5", c2) & vbCrLf & vbCrLf & vbCrLf)


        Dim strlist() As String = {"   ╖ Name : ", "  ╒╡ Time : ", " ╒╬╡ OS : ", " ═╬╡ Version : ", " ╘╬╡ Memory : ", "  ╘╡ Display :", "   ╜ Internet :"}
        Dim varlist() As String = {My.Computer.Name, My.Computer.Clock.LocalTime, My.Computer.Info.OSFullName, My.Computer.Info.OSVersion, My.Computer.Info.AvailablePhysicalMemory & "/" & My.Computer.Info.TotalPhysicalMemory, My.Computer.Screen.Bounds.Width & "x" & My.Computer.Screen.Bounds.Height, My.Computer.Network.IsAvailable}



        T += "                                                                                             ╓  " & vbCrLf
        T += "                                                                                             ╞╕ " & vbCrLf
        T += "                                                                                             ╞╬╕" & vbCrLf
        T += "                                                                                             ╞╬═" & vbCrLf
        T += "                                                                                             ╞╬╛" & vbCrLf
        T += "                                                                                             ╞╛ " & vbCrLf
        T += "                                                                                             ╙  " & vbCrLf


        Console.SetCursorPosition(0, 19)

        Console.Write(colour(T.PastelBg(Color.FromArgb(17, 17, 17)), c1))

        T = String.Empty
        T += "                                                      .+-------.+-------.+--------+" & vbCrLf
        T += "                                                    .' |     .' |     .' |      .'|" & vbCrLf
        T += "                                                   +--------+--------+---+----+'  |" & vbCrLf
        T += "                                                   |   | φΩ |   | πΘ |   | Σµ |   |" & vbCrLf
        T += "                                                   |  ,+----|--,+----|--,+----+---+" & vbCrLf
        T += "                                                   |.'      |.'      |.'      | .' " & vbCrLf
        T += "                                                   +--------+--------+--------+'   " & vbCrLf


        Console.SetCursorPosition(0, 19)

        Console.Write(colour(T.PastelBg(Color.FromArgb(17, 17, 17)), c2))


        Console.SetCursorPosition(0, 19)

        T = String.Empty

        For count = 0 To UBound(strlist)

            T += colour(strlist(count), c1) & vbTab & colour(varlist(count), c2) & vbCrLf

        Next

        Console.Write(T.PastelBg(Color.FromArgb(17, 17, 17)))

        T = String.Empty


        If intro = 0 Then

            For count = 0 To 60

                For yy = 0 To 10

                    For xx = 0 To 27

                        R(xx, yy) = blend({12, blend({227, 20}, sforbl(xx, 37), 37)}, count, 60)
                        G(xx, yy) = blend({12, blend({10, 210}, sforbl(xx, 37), 37)}, count, 60)
                        B(xx, yy) = blend({12, blend({150, 230}, sforbl(xx, 37), 37)}, count, 60)

                    Next

                Next

                C = 0

                For y = 0 To 10

                    For x = 0 To 27

                        T += colour(ChrLogo(y, x), {R(x, y), G(x, y), B(x, y)})

                    Next

                Next

                Thread.Sleep(1)
                Console.SetCursorPosition(0, 6)
                Console.Write(T)
                T = String.Empty

            Next

        ElseIf intro = 1 Then

            For y = 0 To 10

                For x = 0 To 27

                    R(x, y) = blend({227, 20}, sforbl(x, 37), 37)
                    G(x, y) = blend({10, 210}, sforbl(x, 37), 37)
                    B(x, y) = blend({150, 230}, sforbl(x, 37), 37)
                    Console.SetCursorPosition(0, 6)
                    Thread.Sleep(1)
                    T += colour(ChrLogo(y, x), {R(x, y), G(x, y), B(x, y)})
                    Console.Write(T)

                Next

            Next

        ElseIf intro = 2 Then

            For count = 0 To 60

                For yy = 0 To 10

                    For xx = 0 To 27

                        R(xx, yy) = blend({255, blend({227, 20}, sforbl(xx, 37), 37)}, count, 60)
                        G(xx, yy) = blend({255, blend({10, 210}, sforbl(xx, 37), 37)}, count, 60)
                        B(xx, yy) = blend({255, blend({150, 230}, sforbl(xx, 37), 37)}, count, 60)

                    Next

                Next

                C = 0

                For y = 0 To 10

                    For x = 0 To 27

                        T += colour(ChrLogo(y, x), {R(x, y), G(x, y), B(x, y)})

                    Next

                Next

                Thread.Sleep(1)
                Console.SetCursorPosition(0, 6)
                Console.Write(T)
                T = String.Empty

            Next

        ElseIf intro = 3 Then

            For count = 0 To 60

                For yy = 0 To 10

                    For xx = 0 To 27

                        R(xx, yy) = blend({255 - blend({227, 20}, sforbl(xx, 37), 37), blend({227, 20}, sforbl(xx, 37), 37)}, count, 60)
                        G(xx, yy) = blend({255 - blend({10, 210}, sforbl(xx, 37), 37), blend({10, 210}, sforbl(xx, 37), 37)}, count, 60)
                        B(xx, yy) = blend({255 - blend({150, 230}, sforbl(xx, 37), 37), blend({150, 230}, sforbl(xx, 37), 37)}, count, 60)

                    Next

                Next

                C = 0

                For y = 0 To 10

                    For x = 0 To 27

                        T += colour(ChrLogo(y, x), {R(x, y), G(x, y), B(x, y)})

                    Next

                Next

                Thread.Sleep(1)
                Console.SetCursorPosition(0, 6)
                Console.Write(T)
                T = String.Empty

            Next

        ElseIf intro = 4 Then

            Dim vis(27, 10) As Boolean
            Dim xb, yb As Byte
            Dim rand As New System.Random

            xb = rand.Next(0, 27)
            yb = rand.Next(0, 10)

            For y = 0 To 10

                For x = 0 To 27

                    R(x, y) = blend({227, 20}, sforbl(x, 37), 37)
                    G(x, y) = blend({10, 210}, sforbl(x, 37), 37)
                    B(x, y) = blend({150, 230}, sforbl(x, 37), 37)

                Next

            Next

            For count = 0 To 153

                For re = 0 To 1

                    xb = rand.Next(0, 28)
                    yb = rand.Next(0, 11)

                    While vis(xb, yb) = True

                        xb = rand.Next(0, 28)
                        yb = rand.Next(0, 11)

                    End While

                    vis(xb, yb) = True

                Next

                For y = 0 To 10

                    For x = 0 To 27

                        T += If(vis(x, y), colour(ChrLogo(y, x), {R(x, y), G(x, y), B(x, y)}), colour(ChrLogo(y, x), {12, 12, 12}))

                    Next

                Next

                Console.SetCursorPosition(0, 6)
                Thread.Sleep(1)
                Console.Write(T)
                T = String.Empty

            Next

        End If

        Console.SetCursorPosition(0, 27)
        Console.CursorVisible = True
fail:
        Console.ReadKey()

    End Sub

    Function colour(input As String, RGB() As Byte)

        Return input.Pastel(Color.FromArgb(RGB(0), RGB(1), RGB(2)))

    End Function ' colours a string

    Function sforbl(ByVal stepper As Integer, ByVal stepmax As Integer)

        Return stepmax / 2 * (-Math.Cos(stepper / stepmax * 90 * Math.PI / 180 * 2)) + stepmax / 2

    End Function
    Function blend(ByVal RGB() As Single, ByVal stepper As Integer, stepmax As Integer) 'can use stepper values higher than stepmax aslong as output wont be constrained

        Dim F As Integer
        Dim M As Single

        F = RGB(0)
        M = (RGB(1) - F) / stepmax

        Return M * stepper + F

    End Function

End Module