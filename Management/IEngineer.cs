namespace TflScheduling.Management;

public interface IEngineer
{
    /*
     Add or remove journey time delays on track sections between stations in one or both
       directions. E.g. add delay of 5 minutes to Victoria south bound journey from Warren Street
       to Oxford Circus.
     */
    void AddTimeDelayOnTrack();
    
    
    void RemoveTimeDelayOnTrack();
    
    /*
       Close or open track sections between stations in one or both directions, e.g. close Jubilee
       (Eastbound) from Bond Street to Green Park
     */
    void CloseTrackSection();
    
    void OpenTrackSection();
    
    /*
     print out the list of closed track sections, e.g. print closed track sections: Jubilee
       (Eastbound): Bond Street - Green Park - closed
     */
    void PrintClosedTrackSections();
    
    /*
     print out the lists of delayed journey track sections, with normal time and delayed times,
       e.g. print delayed track sections:
       Victoria (Southbound): Warren Street to Oxford Circus-5 min delay
     */
    void PrintDelayedTrainSections();

}