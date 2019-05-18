# TestServerExternalControllerProblem
https://github.com/aspnet/AspNetCore/issues/10331

To repo the problem simply CUT-AND-PASTE the following file;
https://github.com/P7CoreOrg/TestServerExternalControllerProblem/blob/master/src/ExternalValuesApi/Controllers/ValuesExternalController.cs  

To the following location;
https://github.com/P7CoreOrg/TestServerExternalControllerProblem/tree/master/src/TestServerExternalControllerProblem/Controllers  


The api's work with running as a normal app, but I can't get make a call to the valuesexternal api under test.  

https://localhost:5001/api/values  
https://localhost:5001/api/valuesexternal  

