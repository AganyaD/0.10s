print("Aganya hello")

testPars = input();
print(testPars)
split = testPars.split(";")
print ("-----------------------")
print (split)
print ("-----------------------")
for item in split:
	print (item)
print ("-----------------------")
for item in split:
	split2 = item.split(",")
	print (split2)
	print ("-----------------------")

print ("-----------------------")