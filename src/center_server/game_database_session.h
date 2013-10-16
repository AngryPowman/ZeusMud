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
        Poco::Data::SQLite::Connector::enableSharedCache(false);
        Poco::Data::Session session("SQLite", "./data/zeus_mud.db");
        Poco::Data::Statement stmt(session);
        stmt << "SELECT email FROM users", Poco::Data::into(_emails), Poco::Data::now;
        
        std::cout << _emails.size() << std::endl;
        for (size_t i = 0; i < _emails.size(); ++i)
        {
            std::cout << _emails[i] << std::endl;
        }

    }
private:
    std::vector<std::string> _emails;
};

#endif