# CriticalArcTest
## My Definition of "Production Ready"
- Includes Documentation  
I have documented some functions as examples.
- Includes Logging  
I have implemented logging to the Windows Events log as an example and those events logged are not exhaustive.
- Includes Exception Handling  
I have captured and dealt with some exceptions but these are only examples, and a fuller implementation should also log exceptions.
- Includes Unit Tests  
I have supplied some unit tests as demonstrations but many more conditions, methods, and classes need to be mocked and tested.
- Includes Data Validation  
Simple data validation for integer and boolean data has been implemented.
- Promotes Easy Maintainability  
I have provided a couple of sample mechanisms that promote easier expansion of functionality via configuration files, dependency injection, abstract classes, and interfaces.

## Notes
No third party libraries were used as I prefer to minimise such dependencies for better reliability.  
However, two additional system libraries were used; ConfigurationManager and EventLog.  
Also, an initial execution will be needed to setup the event log as no application setup mechanism is included.
