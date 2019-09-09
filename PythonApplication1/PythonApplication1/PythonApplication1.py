print("Aganya hello")
while True:
  testPars = str(raw_input("Enter Command"));
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
