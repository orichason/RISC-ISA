loop:
COPY R1 R25
SET R20 1
SET R21 A
SUB R23 R21 R20
SET R15 1
SUB R23 R23 R20
getRange:
GT R2 R23 R1
JMPT R2 addMin
SHFTR R1 R1 1
JMP getRange
addMin:
ADD R1 R1 R20
SET R0 0
SET R26 1
waitForKey:
EQ R2 R26 R0
JMPT R2 readKey
JMP waitForKey
readKey:
GT R3 R1 R27
JMPT R3 greater
EQ R3 R27 R1
JMPT R3 equal
JMP less
greater:
SET R28 47
SET R29 1
SET R26 1
JMP waitForKey
equal:
SET R28 57
SET R29 1
JMP end
less:
SET R28 4C
SET R29 1
SET R26 1
JMP waitForKey
end:
JMP loop