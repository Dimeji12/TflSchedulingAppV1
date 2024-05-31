namespace TflScheduling.Management;

public interface ICustomer
{
    /*
     Find a route by entering a start and end station and find the fastest route between
       them, displaying the route as a list of stations and indicating any interchanges from one
       line to the next, indicating the new line and direction.
       For example, for a journey from Marble Arch to Great Portland Street the output would be
       like the following:
       Route: Marble Arch to Great Portland Street:
       (1) Start: Marble Arch, Central (Eastbound)
       (2) Central (Eastbound): Marble Arch to Bond Street 1.00min
       Page 6 of 10
       (3) Change: Bond Street Central (Eastbound) to Jubilee(Westbound) 2.00min
       (4) Jubilee (Westbound): Bond Street to Baker Street 2.28min
       (5) Change: Baker Street Jubilee (Westbound) to Circle (Outer) 2.00min
       (6) Circle (Outer): Baker Street to Great Portland Street 1.90min
       (7) End: Great Portland Street, Circle (Outer)
       Total Journey Time: 9.18 minutes
     */

    void FindRoute();

    /*
     Display information about a tube or overground station, similar to that available from
       the TfL web site. (See Tutorial exercises.)
     */
    void DisplayLineInfo();
}