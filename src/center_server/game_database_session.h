#ifndef __GAME_DATABASE_SESSION_H__
#define __GAME_DATABASE_SESSION_H__

#include <singleton.h>
#include <Poco/Data/Common.h>
#include <Poco/Data/SQLite/Connector.h>
#include <Poco/Data/RecordSet.h>
#include <Poco/Data/SessionFactory.h>

class GameDatabaseSession
    : public Venus::Singleton<GameDatabaseSession, false>
{
public:
    GameDatabaseSession(){}
    ~GameDatabaseSession(){}

public:
    void test()
    {
        Poco::Data::Session session(Poco::Data::SessionFactory::instance().create("SQLite", "./data/zeus_mud.db"));
        //Poco::Data::Statement stmt(session);

        std::vector<std::string> emails;
        session << "SELECT email FROM users", Poco::Data::into(emails), Poco::Data::now;
        //session.close();
        //session.execute();
        //session.close();

        /*std::cout << emails.size() << std::endl;
        for (size_t i = 0; i < emails.size(); ++i)
        {
            std::cout << emails[i] << std::endl;
        }
        emails.clear();*/
    }
};

#endif