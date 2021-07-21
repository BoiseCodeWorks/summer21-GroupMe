using System;
using System.ComponentModel.DataAnnotations;

namespace GroupMe.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";

        public Group Group { get; set; } // how to get multiple groups
        public Profile Profile { get; set; }

    }

    // public class Job
    // {
    //     public string CreatorId { get; set; }
    //     public string Description { get; set; }
    //     public bool IsDone { get; set; }
    // }

    // public class Bid // 25+ members
    // {
    //     public int Id { get; set; }
    //     public string AccountId { get; set; } // contractorId
    //     public int JobId { get; set; }
    //     [Required]
    //     [Range(0, int.MaxValue)]
    //     public decimal Estimate { get; set; } = 0;

    //     public Profile Contractor { get; set; }
    //     public Job Job { get; set; }

    //     public void DoThing()
    //     {

    //     }

    //     // I am the job poster
    //     // GET api/bid/7 => {jobId: 13, accountId: 'A3', estimate: 30, contractor: {...} }
    //     // GET api/profiles/a3 => { name: "Jake", ... }

    //     // I am the contractor I need to see the jobs I've bid on
    //     // GET api/profiles/:pid/bids === account/bids => {jobId: 13, accountId: 'A3', estimate: 30 }
    //     // GET api/jobs/:jid => 

    // }

    // public class ContractorBidViewModel
    // {
    //     public int Id { get; set; }

    //     public Job Job { get; set; }
    //     public decimal Estimate { get; set; } = 0;
    // }
    // public class UserBidViewModel
    // {
    //     public int Id { get; set; }

    //     public Profile Contractor { get; set; }
    //     public Job Job { get; set; }
    //     public decimal Estimate { get; set; } = 0;
    // }




    // public abstract class Animal
    // {
    //     public int Id { get; set; }
    //     public virtual void Communicate()
    //     {
    //         System.Console.WriteLine(thing);
    //         System.Console.WriteLine("I am speaking");
    //     }

    //     private string thing { get; set; }
    //     protected string anotherThing { get; set; }

    // }
    // public class Bird : Animal
    // {
    //     public override void Communicate()
    //     {
    //         base.Communicate();
    //         System.Console.WriteLine(anotherThing);
    //         System.Console.WriteLine("Chirp");
    //     }
    // }

    // public class Dog : Animal
    // {
    //     public void Dig()
    //     {
    //         var tweety = new Bird();
    //         tweety.Communicate();
            
    //     }
    // }

}