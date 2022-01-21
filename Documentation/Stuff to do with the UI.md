<u><ins>UI</ins></u>

    (Using WPF to create the UI)
    
Example of a textbox from the converter:  
(This one is used for the decimal value)
```XAML
<TextBox x:Name="decTxtBox" MaxLength="3" LostFocus="decLF" TextWrapping="Wrap" Text="" Grid.Column="3" Margin="0,0,56,11" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" BorderBrush="Red" Foreground="White" Grid.ColumnSpan="2" Grid.Row="1" Grid.RowSpan="2">
            <TextBox.Background>
                <SolidColorBrush Color="Red" Opacity="0.1"/>
            </TextBox.Background>
        </TextBox>
```
Used 'MaxLength' to limit how many characters the user can enter since they will only need to enter 3 at most (largest acceptable value is 255).

'LostFocus' allows me to execute code once the textbox has lost focus. It allows the user to enter what they want and since I've done this for every textbox, it can determine which conversions need to be carried out based on which one has lost focus (or last had a value entered).
```C#
private void decLF(object sender, RoutedEventArgs e)
        {
            //code goes here
        }
```
The subroutine will execute the code within it when the textbox becomes unfocused. In this case it will carry out decimal to hex and binary.  
'decLF' = decimal lost focus
