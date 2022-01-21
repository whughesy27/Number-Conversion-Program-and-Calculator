<u><ins>CONVERTER:</ins></u>

    When the user enters a number, convert them to both other formats at the same time.

INPUT inpVal  
IF inpVal is integer between 0-255  
&emsp;(for binary)  
&emsp;n = 7 (maybe use inpVal.Length?)  
&emsp;ARRAY 0, 0, 0, 0, 0, 0, 0, 0  
&emsp;FOR n >=0  
&emsp;&emsp;IF inpVal >= 2^n  
&emsp;&emsp;&emsp;ARRAY[current position] = 1 (replace the value in the array with a '1'. move along the array each loop)  
&emsp;&emsp;&emsp;n - 1  
  
&emsp;(for hexadecimal)  
&emsp;ARRAY 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F (hexadecimal values)  
&emsp;ARRAY[inpVal / 16] + ARRAY[inpVal % 16] (divide and mod the int to get the 2 hex values)  
  
&emsp;IF inpVal is a binary value  
&emsp;&emsp;(for decimal)  
&emsp;&emsp;FOR inpVal Length  
&emsp;&emsp;&emsp;reverse inpVal (so index value is suitable when doing powers)  
&emsp;&emsp;&emsp;IF inpVal[position in string] = 1  
&emsp;&emsp;&emsp;&emsp;Total + 2^string position (if the current value in the string is a '1', do 2 to the power of the index value and add to the total)  
&emsp;&emsp;&emsp;&emsp;inpVal - 2^string position  
        
    (for hexadecimal)
    use the same method from before using the int 'Total' from the bin to decimal

&emsp;IF inpVal is 2 hexadecimal  
&emsp;&emsp;(for decimal)  
&emsp;&emsp;ARRAY 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F  
&emsp;&emsp;FOR n < 2  
&emsp;&emsp;&emsp;IF inpVal[n] is in ARRAY  
&emsp;&emsp;&emsp;&emsp;Total + index value of n in the array * 16 (only + for second value)  
        
    (for binary)
    use the same method from before using the int 'Total'

<u><ins>CALCULATOR</ins></u>

    Convert both of the entered values to integers using the same method from befor and add them to get the resut for decimal.
    IF 0 >= result <= 255
      Convert the integer back to binary
      OUTPUT both results
