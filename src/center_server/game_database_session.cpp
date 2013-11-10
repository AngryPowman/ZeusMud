#include "game_database_session.h"
#include "player_db.h"

GameDatabaseSession::GameDatabaseSession()
    : _db_session("SQLite", "./data/zeus_mud.db"), _db_stmt(_db_session)
{
}

GameDatabaseSession::~GameDatabaseSession()
{
    _db_session.close();
}


//====================================================================
// ��¼ϵͳ
//====================================================================
bool GameDatabaseSession::checkUserExists(const std::string& email)
{
    _db_stmt = (_db_session 
        << "SELECT email FROM users WHERE email = :email", 
        Poco::Data::limit(1), 
        Poco::Data::use(email));

    return (_db_stmt.execute() > 0);
}

bool GameDatabaseSession::checkNicknameExists(const std::string& nickname)
{
    _db_stmt = (_db_session 
        << "SELECT nickname FROM users WHERE nickname = :nickname", 
        Poco::Data::limit(1), 
        Poco::Data::use(nickname));

    return (_db_stmt.execute() > 0);
}

bool GameDatabaseSession::userAuth(const std::string& email, const std::string& pass_hash)
{
    _db_stmt = (_db_session 
        << "SELECT email, password FROM users WHERE email = :email and password = :password;", 
        Poco::Data::limit(1), 
        Poco::Data::use(email),
        Poco::Data::use(pass_hash)
        );

    return (_db_stmt.execute() > 0);
}

void GameDatabaseSession::insertNewUserRecord(
    uint64 guid, 
    const std::string& email,
    const std::string& password,
    int32 gender,
    const std::string& nickname,
    const std::string& register_ip,
    uint64 register_time
    )
{
    _db_stmt = (_db_session << 
        "INSERT INTO users(guid, email, password, gender, nickname, register_ip, register_time) "
        "VALUES(:guid, :email, :password, :gender, :nickname, :register_ip, :register_time);",
        Poco::Data::use(guid),
        Poco::Data::use(email),
        Poco::Data::use(password),
        Poco::Data::use(gender),
        Poco::Data::use(nickname),
        Poco::Data::use(register_ip),
        Poco::Data::use(register_time));

    _db_stmt.execute();
}

bool GameDatabaseSession::loadPlayerInfo(uint64 guid, PlayerDB* playerDB)
{
    _db_stmt = (_db_session 
        << "SELECT email, gender, nickname, register_ip, register_time, last_login_time "
        "FROM users WHERE guid = :guid;",
        Poco::Data::limit(1), 
        Poco::Data::use(guid),
        Poco::Data::into(playerDB->email),
        Poco::Data::into(playerDB->gender),
        Poco::Data::into(playerDB->nickname),
        Poco::Data::into(playerDB->register_ip),
        Poco::Data::into(playerDB->register_time),
        Poco::Data::into(playerDB->last_login)
        );

    return (_db_stmt.execute() > 0);
}