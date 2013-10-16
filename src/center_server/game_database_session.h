#ifndef __GAME_DATABASE_SESSION_H__
#define __GAME_DATABASE_SESSION_H__

#include <singleton.h>
#include <Poco/Data/Common.h>
#include <Poco/Data/SQLite/Connector.h>
#include <Poco/Data/RecordSet.h>
#include <Poco/Data/SessionFactory.h>
#include "db_user.h"

class GameDatabaseSession
    : public Venus::Singleton<GameDatabaseSession>
{
public:
    GameDatabaseSession();
    ~GameDatabaseSession();

public:
    /*void test()
    {
        std::vector<std::string> _emails;

        _db_stmt << "SELECT email FROM users", Poco::Data::into(_emails), Poco::Data::now;

        std::cout << (_emails).size() << std::endl;
        for (size_t i = 0; i < (_emails).size(); ++i)
        {
            std::cout << _emails[i] << std::endl;
        }
    }*/

    //====================================================================
    // µÇÂ¼ÏµÍ³
    //====================================================================
    bool checkUserExists(const std::string& email)
    {
        Poco::Data::Statement stmt(*_db_session);
        stmt << "SELECT email FROM users WHERE email = :email", Poco::Data::use(email);

        uint32 count = stmt.execute();

        if (count > 0)
        {
            printf("User '%s' has been exists.", email.c_str());
            return true;
        }

        printf("User '%s' not exists.", email.c_str());

        stmt.done();
        return false;
    }

    void insertNewUserRecord(const DBUser& user)
    {
        *_db_stmt << 
            "INSERT INTO users(user_id, email, password, gender, nickname, register_ip, register_timestamp) "
            "VALUES(:user_id, :email, :password, :gender, :nickname, :register_ip, register_timestamp);",
            Poco::Data::use(user.user_id),
            Poco::Data::use(user.email),
            Poco::Data::use(user.password_hash),
            Poco::Data::use(user.gender),
            Poco::Data::use(user.nickname),
            Poco::Data::use(user.register_ip),
            Poco::Data::use(user.register_timestamp);

        _db_stmt->execute();
    }

private:
    Poco::Data::Session* _db_session;
    Poco::Data::Statement* _db_stmt;
};

#endif