using AmosBatista.ExtractFollowLike.Application.ContactNet;

using AmosBatista.ExtractFollowLike.Data.Repository.MySQLDatabase;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;
using System.Linq;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class Network_teste
    {
        public void teste()
        {
            var relationshipReps = new GetRelationshipStatus();
            var userSource = new TwitterAPPUser();
            var userTarget = new TwitterAPPUser();
            var opt = new RepositoryOptions();

            var userRep = new LoadUser();

            opt.twitterUser.screen_name = "amosbatista";
            userSource = userRep.GetUser(opt);

            opt.twitterUser.screen_name = "oficial_cp";
            userTarget = userRep.GetUser(opt);

            opt.twitterUser = userSource;
            opt.twitterUser_Target = userTarget;

            var result = relationshipReps.Get(opt);
            result.ToString();
        }
    }
}
