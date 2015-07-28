Gavin Hurley
gavin.w.hurley@gmail.com
443.695.4710

This project is an implementation of the Mobile Device Keyboard challenge at this address:
http://www.asymmetrik.com/programming-challenges

The project is intended to use the architecture known as hexagonal, or ports-and-adaptors, or the onion.  
The intention is for the Domain project to be considered the center of the system.  The domain defines the objects
to be used and the interfaces for the services that make use of them.  

The infrastructure project contains the implementaton of the data store.  In this case, I used a list in memory, 
but as long as the interface was adhered to, the data store could be swapped out with something else.  

The dependency resolution project is the anchor that enables loose coupling between the projects.  It uses Autofac
to inject concrete classes back to ta callers who request them.  I like autofac becase it will automatically construct 
chains of dependent classes based on their constuctors, as it does with the CandadateService class.  

I used test-driven development to debug the system.  Then I created a simple UI with a windows form.  This could be easily
adapted to respond to an AJAX request from a control on a web page as well.  

Thanks!
g