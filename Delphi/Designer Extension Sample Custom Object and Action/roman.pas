// Conversion code adapted from the freeware package BConvert
// Copyright (c) 1999 Branko Dimitrijevic

unit roman;

interface

function ToRoman(Value: cardinal) : String;

implementation

const
  br=13;
type
  RomanNumbers=array[0..br-1] of string;
  DeximalNumbers= array[0..br-1] of Cardinal;
const (* I V X L C D M *)
  Romans: RomanNumbers = (    'I','IV','V','IX','X','XL','L','XC','C','CD','D','CM','M' );
  Decimals: DeximalNumbers = (1,  4,   5,  9,   10, 40,  50, 90,  100,400, 500,900, 1000);
function ToRoman(Value: cardinal) : String;  
var
  index: 0..br-1;
  a: cardinal;

  function FindMaximumDecimal(const max: Cardinal): Cardinal;
  var
    curr: Cardinal;
  begin
    curr := Low(Decimals);
    while curr < High(Decimals) do
    begin
      if Decimals[curr+1] <= max then
        Inc(curr)
      else
      begin
        if Decimals[curr] <= max then
        begin
          result := curr;
          exit
        end
      end
    end;
    result := High(Decimals)
  end;

begin
  a:=Value;
  result := '';
  while a > 0 do
  begin
    index := FindMaximumDecimal(a);
    Dec(a,Decimals[index]);
    result := result + Romans[index];
  end;
end;

end.

